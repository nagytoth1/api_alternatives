<?php 

require_once '../include/config.php';

function error($status, $message){
    header("HTTP/1.0 ".$status." ".$message);
    $data = array('status' => $status, 'message' => $message, 'data' => null);
    return json_encode($data, JSON_UNESCAPED_UNICODE);
}
function getDolgozok() {
    global $connection; //connection in config.php
    $query_result = mysqli_query($connection, 'SELECT * FROM dolgozo');
    
    if(!$query_result)
        return error(500, 'Internal Server Error');

    if(mysqli_num_rows($query_result) == 0)
        return error(404, 'No Employee Found');

    $employees = mysqli_fetch_all($query_result, MYSQLI_ASSOC);
    header("HTTP/1.0 200 OK");
    return json_encode([
        'status' => 200,
        'message' => 'Employee List Fetched Successfully',
        'data' => $employees
    ], JSON_UNESCAPED_UNICODE);
}

function getDolgozo($id){
    if($id == null)
        return error(422, 'Missing field: id');
    global $connection; //connection in config.php
    $emp_id = trim(mysqli_real_escape_string($connection, $id));
    $query_result = mysqli_query($connection, "SELECT * FROM dolgozo WHERE id = $emp_id LIMIT 1;");
    
    if(!$query_result)
        return error(500, 'Internal Server Error');
    
    if(mysqli_num_rows($query_result) == 0)
        return error(404, 'No employee found');

    header('HTTP/1.0 200 OK');
    return json_encode([
        'status'=>200,
        'message'=>'Employee has been created successfully!',
        'data'=>mysqli_fetch_assoc($query_result)
    ], JSON_UNESCAPED_UNICODE);
}

function storeDolgozo($employee){
    global $connection;

    if(!isset($employee['nev']))
        return error(422, 'Missing field: nev');
    if(!isset($employee['foto']))
        return error(422, 'Missing field: foto');
    if(!isset($employee['reszleg_id']))
        return error(422, 'Missing field: reszleg_id');
    $nev = trim(mysqli_real_escape_string($connection, $employee['nev']));
    $foto = trim(mysqli_real_escape_string($connection, $employee['foto']));
    $reszleg_id = trim(mysqli_real_escape_string($connection, $employee['reszleg_id']));

    $query_result = mysqli_query($connection, 
                           "INSERT INTO dolgozo (nev, foto, reszleg_id) VALUES ('$nev', '$foto', '$reszleg_id');");
    if(!$query_result)
        return error(500, 'Internal Server Error');
    
    header('HTTP/1.0 201 Created');
    return json_encode([
        'status'=>201,
        'message'=>'Employee has been created successfully!',
        'data'=>$query_result
    ]);
}

function deleteDolgozo($id){
    if($id == null)
        return error(422, 'Missing field: id');
    global $connection; //connection in config.php
    $emp_id = trim(mysqli_real_escape_string($connection, $id));
    $query_result = mysqli_query($connection, "DELETE FROM dolgozo WHERE id = $emp_id LIMIT 1;");
    if(!$query_result)
        return error(500, 'Internal Server Error');
    if(mysqli_affected_rows($connection) == 0)
        return error(404, 'Employee not found');

    header('HTTP/1.0 200 OK');
    return json_encode([
        'status'=>200,
        'message'=>'Employee has been deleted successfully!',
		'data'=>null
    ], JSON_UNESCAPED_UNICODE);
}

function updateDolgozo($employee, $id){
    if(!isset($employee['nev']))
        return error(422, 'Missing field: nev');
    if(!isset($employee['foto']))
        return error(422, 'Missing field: foto');
    if(!isset($employee['reszleg_id']))
        return error(422, 'Missing field: reszleg_id');
    global $connection;
    $nev = trim(mysqli_real_escape_string($connection, $employee['nev']));
    $foto = trim(mysqli_real_escape_string($connection, $employee['foto']));
    $reszleg_id = trim(mysqli_real_escape_string($connection, $employee['reszleg_id']));
    $query_result = mysqli_query($connection, "UPDATE dolgozo SET nev = '$nev', foto = '$foto', reszleg_id = $reszleg_id WHERE id = $id LIMIT 1;");
    if(!$query_result)
        return error(500, 'Internal Server Error');
    if(mysqli_affected_rows($connection) == 0)
        return error(404, 'Employee not found');

    header('HTTP/1.0 200 Success');
    return json_encode([
        'status'=>200,
        'message'=>'Employee has been updated successfully!'
		'data'=>null
    ], JSON_UNESCAPED_UNICODE);
}