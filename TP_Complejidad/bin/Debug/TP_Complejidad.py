import json
import math
class Nodo:
    def __init__(self,X,Y,N):
        self.lon=X
        self.lat=Y
        self.nombre=N
coordenadas=[]
restantes=[]
camino=[]
def leer_datos():
    archivo = open("UNO_CERO.txt", 'r')
    for linea in archivo.readlines():
        UNO_CERO = str(linea)
    archivo.close()
    return UNO_CERO
def cargar_datos(ruta):
    UNO_CERO=leer_datos()
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('CAPITAL')==UNO_CERO:
                nuevo=Nodo(i.get('properties').get('XGD'),i.get('properties').get('YGD'),i.get('properties').get('DEP'))
                coordenadas.append(nuevo)
                print(cont," ",coordenadas[cont].nombre,"\t Lon: ",coordenadas[cont].lon," La: ",coordenadas[cont].lat)
                cont+=1
def calcular_peso(lat1,lon1,lat2,lon2):
    rad=math.pi/180
    dlat=lat2-lat1
    dlon=lon2-lon1
    R = 6372.795477598
    a = (math.sin(rad*dlat / 2))**2 + math.cos(rad * lat1) * math.cos(rad * lat2) * (math.sin(rad * dlon / 2)) **2;
    distancia = 2 * R * math.asin(math.sqrt(a))
    return distancia
def esta_dentro(i,primer_Nodo,Rango):
    arriba=primer_Nodo.lat + Rango
    abajo =primer_Nodo.lat - Rango
    derecha=primer_Nodo.lon + Rango
    izquierda =primer_Nodo.lon - Rango
    if i.lon<derecha and i.lon>izquierda and i.lat >abajo and i.lat<arriba:
        return True
    else:
        return False
def guardar():
    mi_path = "lista.txt"
    f = open(mi_path, 'w')
    for i in camino:
        linea=str(i.lon)+"\n"+str(i.lat)+"\n"
        f.write(linea)
    f.close()
def hallar_cercanos(candidatos,primer_Nodo,Rango,suma):
    cont=0
    for i in restantes:
        if esta_dentro(i,primer_Nodo,Rango) == True:
            aux=[i,cont]#Para guardar con su posicion en restantes
            candidatos.append(aux)
        cont+=1
    if len(restantes) != 1:
        if len(candidatos)>=2:
            menor=100000000
            indice=0
            for i in candidatos:
                distancia=calcular_peso(primer_Nodo.lat,primer_Nodo.lon,i[0].lat,i[0].lon)
                if distancia<menor:
                    menor=distancia
                    indice=i[1]
                print("Distancia de ",primer_Nodo.nombre," hasta ",i[0].nombre," es : ",distancia)
            candidatos=[]
            suma=suma+menor
            nodo=restantes[indice]
            restantes.pop(indice)
            camino.append(nodo)
            #guardar()
            cont2=0
            for i in camino:
                print(cont2," ",i.nombre)
                cont2+=1
            input()
            hallar_cercanos(candidatos,nodo,0.5,suma)
        else:
            candidatos=[]
            hallar_cercanos(candidatos,primer_Nodo,Rango+0.5,suma)
    else:
        suma=suma+calcular_peso(camino[-1].lat,camino[-1].lon,restantes[0].lat,restantes[0].lon)
        camino.append(restantes[0])
        restantes.pop(0)
        #print("La suma total es ", suma)
        #guardar()
def ruta_final():
    cont3=0
    print("La ruta final es :")
    for i in camino:
        print(cont3," ",i.nombre)
        cont3+=1
suma=0
ruta='Archivo.json'
candidatos=[]
cargar_datos(ruta)
restantes=coordenadas #Se ccopia todos los datos a un aux
pos=int(input("Ingrese la ciudad con la que sedea empezar (pos) "))
camino.append(coordenadas[pos])
primer_Nodo=coordenadas[pos] #Se saca el nodo por el que se comenzara
restantes.pop(pos)#Elimina el que ya se agrego
hallar_cercanos(candidatos,primer_Nodo,0.5,suma)
camino.append(primer_Nodo)
ruta_final()
guardar()
input()
