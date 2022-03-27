--    vložení nového záznamu
    INSERT INTO `demo`(`id`, `number`, `text`, `date`) VALUES ([value-1],[value-2],[value-3],[value-4])
--    úpravu záznamu
    UPDATE `demo` SET `id`=[value-1],`number`=[value-2],`text`=[value-3],`date`=[value-4] WHERE 1
--    smazání záznamu
    DELETE FROM `demo` WHERE 0
--    výběr s projekcí
    SELECT `id`,`number`,`text`,`date` FROM `demo`
--    výběr s projekcí a novým dopočítaným sloupcem
    SELECT `id`,`number`,`text`,`date`, number+60 'number+60' FROM `demo`
--    výběr se selekcí (užijte porovnání i logické spojky)
--    jenom ty co mají sudé "number"
    SELECT * FROM `demo` WHERE number%2 = 0 
--    výběr s řazením
    SELECT * FROM `demo` ORDER BY number ASC
--    výběr s limitem
    SELECT * FROM `demo` LIMIT 100
--    práci s textem
--    jen velká písmena
    SELECT `number`,UPPER(`text`),`date` "date" FROM `demo`
--    práci s datumem
--    jiný formát datumu
    SELECT `number`,`text`,DATE_FORMAT(date, "%d. %m. %Y") "date" FROM `demo`