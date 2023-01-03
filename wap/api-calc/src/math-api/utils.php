<?php

function processData(Array $data) {
    $op = ["add", "sub", "mul", "div"];
    if(isset($data["operation"]) && in_array($data["operation"], $op)){
        if(isset($data["numbers"])) {
            $rawnums = explode(',', $data["numbers"]);
            $num = [];

            for($i = 0; $i < sizeof($rawnums); $i++) {
                if (is_numeric($rawnums[$i])) {
                    array_push($num, floatval($rawnums[$i]));
                }
            }

            if(sizeof($num) < 1) {
                wrongDataError();
            }

            header('HTTP/1.1 200 OK');
            switch($data["operation"]){
                case "add":
                    $result = json_encode(array("status" => "OK", "result" => addNumbers($num)));
                    break;
                case "sub":
                    $result = json_encode(array("status" => "OK", "result" => subNumbers($num)));
                    break;
                case "mul":
                    $result = json_encode(array("status" => "OK", "result" => mulNumbers($num)));
                    break;
                case "div":
                    $result = json_encode(array("status" => "OK", "result" => divNumbers($num)));
                    break;
            }
            return $result;
        } else {
            wrongDataError();
        }
    } else {
        wrongDataError();
    }
}

function addNumbers(Array $num){
    $result = 0;
    for ($i = 0; $i < sizeof($num);$i++) {
        $result += $num[$i];
    }
    return $result;
}

function subNumbers(Array $num) {
    $result = 0;
    for ($i = 0; $i < sizeof($num);$i++) {
        $result -= $num[$i];
    }
    return $result;
}

function mulNumbers(Array $num) {
    $result = $num[0];
    for ($i = 1; $i < sizeof($num);$i++) {
        $result *= $num[$i];
    }
    return $result;
}

function divNumbers(Array $num) {
    $result = $num[0];
    for ($i = 1; $i < sizeof($num);$i++) {
        $result /= $num[$i];
    }
    return $result;
}

function wrongDataError() {
    header('HTTP/1.1 422 Unprocessable Entity');
    echo json_encode(array("status" => "ERROR", "reason" => "Wrong Data"));
    die();
}