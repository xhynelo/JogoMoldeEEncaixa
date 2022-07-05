#Entradas:
#1: elemento Path de uma imagem SVG
#2: indica se é pra ser escalonado no eixo Y ou não. Se não for no Y será no X
#3: limite da imagem no eixo indicado entre -LH e + LH (exemplo: LH = 4: o maior valor entre as coordenada será 4 e o menor -4. Se maior valor for 18 passa a ser 4)
#4: deslocamento dos pontos no eixo X
#5: deslocamento dos pontos no eixo Y
#Saida:
#1: retorna uma string com um trexo de código em c# adicionando um Vector3 numa lista de Vector3 chamadas Pontos

def desenha(desenho, ehY, LH, desX = 0, desY = 0):
    coordenadas2 = retornaCoordenada(desenho)
    
    pos0 = (0,0)
    posicoes = []
    posicoes.append(pos0)
    for posn in coordenadas2:
        posp = (pos0[0] + posn[0], pos0[1] + posn[1])
        posicoes.append(posp)
        pos0 = posp
    
    tminX = float("inf")
    tmaxX = float("-inf")
    tminY = float("inf")
    tmaxY = float("-inf")
    for i in posicoes:
        if i[0] < tminX:
            tminX = i[0]
        if i[0] > tmaxX:
            tmaxX = i[0]
        if i[1] < tminY:
            tminY = i[1]
        if i[1] > tmaxY:
            tmaxY = i[1]
    
    distx = tmaxX - tminX
    disty = tmaxY - tminY
    
    centralizada = []
    for i in posicoes:
        x = i[0] - distx/2 - tminX
        y = i[1] - disty/2 - tminY
        centralizada.append((x, y))
    
    if(ehY):
        proporcao = LH / (disty/2)
    else:
        proporcao = LH / (distx/2)

    posicoesFinais = []
    for x,y in centralizada:
        posicoesFinais.append((corverte(x, proporcao), corverte(y, proporcao)))
    
    cs = ""
    for x,y in posicoesFinais:
        cs += f"        pontos.Add(new Vector3(deslocamento + {x + desX}f, {-y + desY}f, 0.0f));\n"
    
    return cs

def corverte(pos, proporcao):
    return pos * proporcao

def retornaCoordenada(desenho):
    b = desenho.split(" ")
    coordenadas = []
    modo = "l"
    for c in b[1:-1]:
        if(c in ["l","h","v"]):
            modo = c
        elif(modo == "l"):
            coordenadas.append(tuple(map(float, c.split(","))))
        elif(modo == "h"):
            coordenadas.append((float(c),0))
        elif(modo == "v"):
            coordenadas.append((0, float(c)))
    return coordenadas[1:]
    
a = "m 104.72174,1273.2206 113.76077,54.3524 22.75212,-24.0161 39.18427,-2.528 -8.84807,-36.6563 12.64008,-29.0722 z"

print(desenha(a, False, 6, desX = 0, desY = 0.2))