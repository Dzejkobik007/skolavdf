# Pokus byl...
graph = [
    [0,0,0,1,0],
    [4,0,0,0,0],
    [2,5,0,0,0],
    [3,0,1,0,1],
    [6,3,2,9,0]
]
while True:
    i = 0
    print("-------")
    lastBiggestVal = 0
    lastBiggestNode = -1
    for j in range(0, 5):
        if i == j or graph[i][j] < 1:
            continue
        if lastBiggestVal < graph[i][j]:
            lastBiggestVal = graph[i][j]
            lastBiggestNode = j
        print("Source: {}, Destination: {}, Value: {}".format(i, j, graph[i][j]))
    if lastBiggestNode < 0:
        break
    i = lastBiggestNode
    print("Continue to Destination: {} with Value: {}".format(lastBiggestNode, lastBiggestVal))
