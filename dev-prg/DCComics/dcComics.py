class DCComics:
    def __init__(self, name : str, born : int, weapons : list, bestActorName : str):
        self.__name = str(name)
        self.__born = int(born)
        self.__weapons = list(weapons)
        self.__bestActorName = str(bestActorName)
    def setName(self,name : str):
        self.__name = name
    def setBorn(self,born : int):
        self.__born = born
    def setBestActorName(self,bestActorName : str):
        self.__bestActorName = bestActorName
    def getName(self):
        return self.__name
    def getBorn(self):
        return self.__born
    def getBestActorName(self):
        return self.__bestActorName
    def addWeapon(self, weapon : str):
        self.__weapons.append(weapon)
    def removeWeapon(self, weapon : str):
        self.__weapons.remove(weapon)
    def getWeapons(self):
        return self.__weapons

dc = DCComics("test", 1, ["weapon1","weapon2","weapon3","weapon4"], "Bestactor")
print("Name:",dc.getName())
print("BestActorName:",dc.getBestActorName())
print("Born:",dc.getBorn())
print("Weapons:",dc.getWeapons())
dc.setName("comicsname")
dc.setBorn(10)
dc.setBestActorName("Actor2000")
dc.addWeapon("gigaweapon")
dc.removeWeapon("weapon2")
print("=================================================================")
print("Name:",dc.getName())
print("BestActorName:",dc.getBestActorName())
print("Born:",dc.getBorn())
print("Weapons:",dc.getWeapons())