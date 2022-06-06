import mysql.connector as db
from mysql.connector import Error

class database:
    def __init__(self, host, user, password, database):
        self.host = host
        self.user = user
        self.password = password
        self.database = database
        self.connect()

    def connect(self):
        try:
            self.connection = db.connect(host=self.host, database=self.database, user=self.user, password=self.password)
            if self.connection.is_connected():
                db_Info = self.connection.get_server_info()
                print("Connected to MySQL Server version ", db_Info)
                cursor = self.connection.cursor()
                cursor.execute("select database();")
                record = cursor.fetchone()
                print("You're connected to database: ", record)
                cursor.close()
        except Error as e:
            print("Error while connecting to MySQL", e)
            exit
    def query(self, query):
        cursor = self.connection.cursor()
        cursor.execute(query)
        return cursor
    def close():
        self.connection.close()

conn = database("127.0.0.1", "comics", "123456789", 'comics')
if conn.connection.is_connected():
    charname = input("Character Name: ")
    weapon = input("Weapon: ")
    cr = conn.query("SELECT * FROM studio;")
    for (id, name) in cr:
        print("{}: {}".format(id, name))
    cr.close()
    stnum = input("Studio Number:")
    res.conn.query("INSERT INTO `charact` (`name`, `weapon`, `studio_id`) VALUES ('{}', '{}', '{}');".format(charname,weapon,stnum))
    res.close()