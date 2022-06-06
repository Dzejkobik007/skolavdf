class Triangle():
    def __init__(self,side = 3):
        self.side = side
    def numOfSides(self):
        return self.side
class Pentagon():
    def __init__(self,side = 5):
        self.side = side
    def numOfSides(self):
        return self.side
class Octagon():
    def __init__(self,side = 8):
        self.side = side
    def numOfSides(self):
        return self.side
class Polygon:
    def __init__(self):
        self.a = Triangle()
        self.b = Pentagon()
        self.c = Octagon()
    def numOfSides(self):
        print("a:",self.a.numOfSides())
        print("b:",self.b.numOfSides())
        print("c:",self.c.numOfSides())

pol = Polygon()
pol.numOfSides()