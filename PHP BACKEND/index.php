<?php

$servername = "";

$username = "";

$password = '';

$dbname = "";

$conn = new mysqli($servername, $username, $password, $dbname);

// CONNECT TO THE DATABASE

if ($conn->connect_error) {

    die("We ran into an error while trying to connect to the database <br> <strong> More Info: " . $conn->connect_error) . "</strong>";

}



// SETUP HEADERS

header("Access-Control-Allow-Origin: *");

header("Content-Type: application/json; charset=UTF-8");



if (empty($_POST) && $_SERVER['REQUEST_METHOD'] === 'POST') {

    $noPostData = array("Error" => "Please enter post data.");

    echo json_encode($noPostData);

  }

  

 // CHECK VALID REQUEST SESSION

 if ($_SERVER['REQUEST_METHOD'] === 'GET') {

    $invalidRequest = array("Error" => "You cant send GET requests to this URL");

    echo json_encode($invalidRequest);

    exit;

}

if($_POST['action'] === 'exampleHTTPRequest'){

    $command = "SELECT * FROM example_products";

    $commandExecute = $conn->query($command);

    $data = array();

    while($dataRow = mysqli_fetch_assoc($commandExecute)){

        $data[] = $dataRow;

    }

    echo json_encode($data);

}

 if(isset($_POST['requestSession'])){

    try {

        $sId = mysqli_real_escape_string($conn, $_POST['requestSession']);

        $stmt = $conn->prepare("SELECT * FROM example_sessions WHERE sessionHash = ?");

        $stmt->bind_param("s", $sId);

        $stmt->execute();

        $getSessionData = $stmt->get_result();

        if(mysqli_num_rows($getSessionData) === 0){

            $invalidSession = array("Error" => "This session is invalid.");

            echo json_encode($invalidSession);

            

        }else{

            if(isset($_POST['action'])){

                if($_POST['action'] === 'exampleHTTPLogin'){

                    $stmt = $conn->prepare("SELECT * FROM example_users WHERE username = ? AND password = ?");

                    $stmt->bind_param("ss", $_POST['username'], $_POST['password']);

                    $stmt->execute();

                    $responseData = $stmt->get_result();                    

                    if(mysqli_num_rows($responseData) === 0){

                        $invalidSession = array("Error" => "Invalid username or password, please try again.");

                        echo json_encode($invalidSession);

                    }

                    else{

                        $loggedIn = array("message" => "You logged in successfully !","username" => $_POST['username']);

                        echo json_encode($loggedIn);

                        header("session_id: " . $_POST['requestSession']);

                        $destroySession= $conn->prepare("DELETE FROM example_sessions WHERE sessionHash = ?");

                        $destroySession->bind_param("s",$_POST['requestSession']);

                        $destroySession->execute();

                    }

                }

                else if($_POST['action'] === 'exampleHTTPRegister'){

                    if(isset($_POST['username'])){

                        if(isset($_POST['password'])){

                            if(isset($_POST['email'])){



                                // CHECK VALID username

                                $checkValidUser = $conn->prepare("SELECT * FROM example_users WHERE username = ?");

                                $checkValidUser->bind_param("s",$_POST['username']);

                                $checkValidUser->execute();

                                if(mysqli_num_rows($checkValidUser->get_result()) === 0){

                                    $checkValidEmail = $conn->prepare("SELECT * FROM example_users WHERE email = ?");

                                    $checkValidEmail->bind_param("s",$_POST['email']);

                                    $checkValidEmail->execute();

                                    if(mysqli_num_rows($checkValidEmail->get_result()) === 0){

                                        $registerUsername = $_POST['username'];

                                        $registerPassword = $_POST['password'];

                                        $registerEmail = $_POST['email'];

                                        $generateToken = bin2hex(random_bytes(32));

                                        $prepareRegister = $conn->prepare("INSERT INTO example_users(username,password,token,email)VALUES(?,?,?,?)");

                                        $prepareRegister->bind_param("ssss",$registerUsername,$registerPassword,$generateToken,$registerEmail);

                                        $prepareRegister->execute();

                                        $succesRegister = array

                                        ("message" => "You Successfully Registered",

                                        "username" => "$registerUsername",

                                        "email" => "$registerEmail",

                                        "token" => "$generateToken");

                                        echo json_encode($succesRegister);

                                        header("session_id: " . $_POST['requestSession']);

                                        $destroySession= $conn->prepare("DELETE FROM example_sessions WHERE sessionHash = ?");

                                        $destroySession->bind_param("s",$_POST['requestSession']);

                                        $destroySession->execute();

                                    }

                                    else{

                                        $errorRegisterOne = array("Error" => "This username OR Email are already used.");

                                        echo json_encode($errorRegisterOne);

                                    }

                                }

                                else{

                                    $errorRegisterTwo = array("Error" => "This username OR Email are already used.");

                                    echo json_encode($errorRegisterTwo);

                                }



                            }

                            else{

                                $invalidEmail = array("Error" => "Please enter email.");

                                echo json_encode($invalidEmail);

                            }

                        }

                        else{

                            $invalidPassword = array("Error" => "Please enter password.");

                            echo json_encode($invalidPassword);

                        }

                    }

                    else{

                $invalidUsername = array("Error" => "Please enter username.");

                 echo json_encode($invalidUsername);

                    }

                }

            }

            else{

                $noAction = array("Error" => "Please enter valid action.");

                 echo json_encode($noAction);



            }

        }

    } catch (Exception $e) {

        echo "Error: " . $e->getMessage();

    }

}
else{
    $noSession = array("Error" => "Please enter request session.");

    echo json_encode($noSession);
}

