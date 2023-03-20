<?php

class MySQL implements IDB
{
    private ?mysqli $db;

    public function connect(
        string $host = "",
        string $username = "",
        string $password = "",
        string $database = ""
    ): ?static {
        $db = mysqli_connect($host, $username, $password, $database);
        if ($db === false) {
            return null;
        }
        $this->db = $db;
        return $this;
    }

    function select(string $query): array {
        $result = mysqli_query($this->db,$query);
        if (
            $result instanceof mysqli_result
            && $result->num_rows > 0
        ){
            return mysqli_fetch_all($result, MYSQLI_ASSOC);
        }
        return [];
    }

    function insert(string $table, array $data): bool {      
        $keys = "(";
        $values = "(";
        foreach(array_keys($data) as $key) {
            $keys .= "'".$key."', ";
        }
        foreach($data as $row) {
            $values .= "'".$row."', ";
        }
        $keys .= ")";
        $values .= ")";
        $query = "INSERT INTO `".$table."` ".$keys." VALUES ".$values;
        $result = mysqli_query($this->db, $query);
        return $result ? true : false;
    }

    function update(string $table, int $id, array $data): bool {
        $query = "INSERT INTO `".$table."` VALUES (";
        for($i = 0; $i < sizeof($data); $i++) {
             $query .= "'".$data[$i]."', ";
        }
        $query .= ")";
        $result = mysqli_query($this->db, $query);
        return $result ? true : false;
    }

    function delete(string $table, int $id): bool {
        $result = mysqli_query($this->db, "DELETE FROM ".$table." WHERE id=".$id);
        return $result ? true : false;
    }

}