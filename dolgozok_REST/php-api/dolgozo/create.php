<?php

header('Access-Control-Allow-Origin:*');
header('Content-Type: application/json');
header('Access-Control-Allow-Method: POST');
header('Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Request-With');
include_once __DIR__.'/functions.php';

$requestMethod = $_SERVER['REQUEST_METHOD'];

if($requestMethod != 'POST'){
    echo json_encode([
        'status' => 405,
        'message' => $requestMethod. ' - Method Not Allowed'
    ]);
    header("HTTP/1.0 405 Method Not Allowed");
    exit(405);

}

$input = json_decode(file_get_contents('php://input'), true);
//send data without form tag
if(empty($input)){
    $result = storeDolgozo($_POST);
}
else{
    $result = storeDolgozo($input);
}

echo $result;