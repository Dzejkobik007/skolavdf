<?php

$count = 400;

$sql = "INSERT INTO `demo`(`number`, `text`, `date`) VALUES \n";
for($i = 0; $i < $count; $i++) {
    $sql .= "(".random_int(1,300).",'".random_string(random_int(20,50))."','2022-".random_int(1,12) ."-". random_int(1,25)."')";
    if ($i < $count - 1) {
        $sql .= ",\n";
    }
}
$file = fopen("rows.sql", "w");
fwrite($file, $sql);
fclose($file);

// Function from https://stackoverflow.com/questions/4356289/php-random-string-generator
function random_string($length = 10) {
    $characters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}