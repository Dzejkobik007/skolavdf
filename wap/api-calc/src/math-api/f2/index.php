<?php

require_once "../utils.php";

header("Content-Type: application/json; charset=UTF-8");

$skipnum = 2;

$uri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$uri = explode( '/', $uri );
if(isset($uri[1+$skipnum])){
    $data["operation"] = $uri[1+$skipnum];
    $numbers = "";
    for($i = 2; $i < sizeof($uri) - $skipnum;$i++){
        $numbers .= $uri[$i+$skipnum];
        $numbers .= ",";
    }
    $data["numbers"] = $numbers;

    echo processData($data);
} else {
    wrongDataError();
}

