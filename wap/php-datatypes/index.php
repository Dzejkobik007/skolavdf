<?php
$datatypes = ["int", "string", "float"];
$testreturns = [
    [10, 2, 10000],
    ["asda", "saaaaaaa", "ssae2w2fjkloiuhygfd", "20", "20,2"],
    [102, 0.0000002, 100, 00, 12315, 1231698]
];


for ($i = 0; $i < sizeof($datatypes); $i++) {
    for ($p = 0; $p < sizeof($datatypes); $p++) {
        for ($k = 0; $k < sizeof($testreturns); $k++) {
            if ($datatypes[$i] == "string"){   
                $func = 'function test('.$datatypes[$i].' $input = "'.$testreturns[$i][$k].'"): '.$datatypes[$p].' { return $input; } try { return test(); } catch (Exception $e) { return "Exception";}';
            } else {
                $func = 'function test('.$datatypes[$i].' $input = '.$testreturns[$i][$k].'): '.$datatypes[$p].' { return $input; } try { return test(); } catch (Exception $e) { return "Exception";}';
            }
            var_dump(eval($func));
            
            // echo $func;
        }
    }
}



try {
    
    
} catch (Exception $e) {
    // echo $e;
}
