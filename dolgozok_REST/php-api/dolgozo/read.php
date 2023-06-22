<?php

header('Access-Control-Allow-Origin:*');
header('Content-Type: application/json');
header('Access-Control-Allow-Method: GET');
header('Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Request-With');
include_once __DIR__.'/functions.php';

$requestMethod = $_SERVER['REQUEST_METHOD'];

if($requestMethod != 'GET'){
    echo json_encode([
        'status' => 405,
        'message' => $requestMethod. ' - Method Not Allowed'
    ]);
    header("HTTP/1.0 405 Method Not Allowed");
    exit(405);

}

if(isset($_GET['id']))
    echo getDolgozo($_GET['id']);
else
    echo getDolgozok();