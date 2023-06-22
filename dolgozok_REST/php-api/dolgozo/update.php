<?php
header('Access-Control-Allow-Origin:*');
header('Content-Type: application/json');
header('Access-Control-Allow-Method: PUT');
header('Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Request-With');
include_once __DIR__.'/functions.php';

$requestMethod = $_SERVER['REQUEST_METHOD'];

if($requestMethod != 'PUT'){
    echo json_encode([
        'status' => 405,
        'message' => $requestMethod. ' - Method Not Allowed'
    ]);
    header("HTTP/1.0 405 Method Not Allowed");
    exit(405);
}

$input = json_decode(file_get_contents('php://input'), true);
//send data without form tag
if(!isset($_GET['id'])){
    echo json_encode([
        'status' => 422,
        'message' => $requestMethod. ' - Missing field: id'
    ]);
    header("HTTP/1.0 422 Missing Field");
    exit(422);
}

if(empty($input)){
    $result = updateDolgozo($_POST, $_GET['id']);
}
else{
    $result = updateDolgozo($input, $_GET['id']);
}

echo $result;