<?php

$EXECUTABLE = "php";

$datatypes = ["int", "string", "float"];
$testreturns = [
    [10, 2, 10000],
    ["asda", "saaaaaaa", "ssae2w2fjkloiuhygfd", "20", "20,2"],
    [102, 0.0000002, 100, 00, 12315, 1231698]
];

$results = array();
$run = 0;
for ($i = 0; $i < sizeof($datatypes); $i++) {
    for ($p = 0; $p < sizeof($datatypes); $p++) {
        for ($k = 0; $k < sizeof($testreturns); $k++) {
            if ($datatypes[$i] == "string"){   
                $func = '<?php function test('.$datatypes[$i].' $input = "'.$testreturns[$i][$k].'"): '.$datatypes[$p].' { return $input; } echo test();';
            } else {
                $func = '<?php function test('.$datatypes[$i].' $input = '.$testreturns[$i][$k].'): '.$datatypes[$p].' { return $input; } echo test();';
            }

            $file = fopen("test.php", "w");
            fwrite($file, $func);
            fclose($file);

            //var_dump($func);
            $results[$run]["input_datatype"] = var_export($datatypes[$i], true);
            $results[$run]["input"] = var_export($testreturns[$i][$k], true);
            $results[$run]["output_datatype"] = var_export($datatypes[$p], true);
            $results[$run]["output"] = var_export(shell_exec($EXECUTABLE." -f test.php"), true);

            $run++;
            // echo $func;
        }
    }
}
var_dump($results);

$file = fopen("results.csv", "w");
for($i = 0; $i < sizeof($results); $i++) {
    fwrite($file, $results[$i]["input_datatype"].";".$results[$i]["input"].";".$results[$i]["output_datatype"].";".$results[$i]["output"]."\n");
}
fclose($file);