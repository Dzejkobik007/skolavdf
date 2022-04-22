import os
import math
os.system("clear")

class bod:
  def __init__(self, x, y):
    self.x = int(x)
    self.y = int(y)
  def set(self,x,y):
    self.x = int(x)
    self.y = int(y)

class usecka:
  def __init__(self,aa=0,ab=0,ba=0,bb=0):
    self.a = bod(aa,ab)
    self.b = bod(bb,ba)
  def delkaUsecky(self):
    i = math.pow(self.a.x - self.b.x, 2)
    u = math.pow(self.a.y - self.b.y, 2)
    return math.sqrt(i + u)

ab = usecka(10,5,15,20)

print("A:","x:",ab.a.x,"y:",ab.a.y)
print("B:","x:",ab.b.x,"y:",ab.b.y)

print("Delka:",ab.delkaUsecky())