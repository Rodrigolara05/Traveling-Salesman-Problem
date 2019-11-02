import json
import math
from operator import itemgetter
global Dist
lista=[]
class Nodo:
    def __init__(self,X,Y,N):
        self.lon=X
        self.lat=Y
        self.nombre=N
coordenadas=[]
ruta_orden=[]

def calcular_peso(lat1,lon1,lat2,lon2):
    rad=math.pi/180
    dlat=lat2-lat1
    dlon=lon2-lon1
    R = 6372.795477598
    a = (math.sin(rad*dlat / 2))**2 + math.cos(rad * lat1) * math.cos(rad * lat2) * (math.sin(rad * dlon / 2)) **2;
    distancia = 2 * R * math.asin(math.sqrt(a))
    return distancia

def cargar_capitales(ruta,numero):#departamental 1,provincial 2, distrital 3
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('CAPITAL')==numero:
                nuevo=Nodo(i.get('properties').get('XGD'),i.get('properties').get('YGD'),i.get('properties').get('DIST'))
                coordenadas.append(nuevo)
                #print(cont," ",coordenadas[cont].nombre,"\t Lon: ",coordenadas[cont].lon," La: ",coordenadas[cont].lat)
                cont+=1
def guardar():
    mi_path = "Ciudades.txt"
    f = open(mi_path, 'w')
    for i,j in ruta_orden:
        linea=str(i)+"\n"+str(j)+"\n"
        f.write(linea)
    f.close()
    
def matriz(lista):
    matriz_distancia=[]
    for i in range(len(lista)):
        aux=[]
        for j in range(len(lista)):
            if(i!=j):
                aux.append((j,round(calcular_peso(lista[i].lat,lista[i].lon,lista[j].lat,lista[j].lon))))
        matriz_distancia.append(aux)
    menor=math.inf
    aux2=[]
    for v,w in matriz_distancia[0]:
        if(w<menor):
            aux2=[(v,w)]
            menor=w
    matriz_distancia[0]=aux2
    return matriz_distancia

def buscar(nodox,restantes):
    for i in range(len(restantes)):
        if restantes[i]==nodox:
            return i        
 
def calcular_distancias_iniciales(G, origen):
    global Dist
    Dist = [math.inf]*len(G)
    for (v,w) in G[origen]:
        Dist[v] = w
    Dist[origen] = 0




def diligencia(G, origen):
    global Dist
    for (v,w) in G[origen]:
        #print(str(Dist[origen] + w),"<=",str(Dist[v]))
        #input()
        if Dist[origen] + w <= Dist[v]:
            Dist[v] = Dist[origen] + w
            lista[v] = [v,Dist[origen] + w]
            diligencia(G, v)


def ordenar(lista):
    aux=sorted(lista, key=itemgetter(1))
    print(aux)
    ida=[]
    vuelta=[]
    for i in range(len(aux)):
        if i%2==0:
            ida.append(aux[i])
        else:
            vuelta.append(aux[i])
    print("Ida: ",ida)
    print("Vuelta: ",vuelta)
    vuelta_reversa = sorted(vuelta, key=itemgetter(1),reverse=True)
    vuelta_reversa.append(ida[0])
    print("Vuelta: ",vuelta_reversa)
    
    
#Nombre el archivo   
ruta='Archivo.json'
#Sacan los datos del archivo
cargar_capitales(ruta,'1')
#Se convierte en una matriz
mat=matriz(coordenadas)

lista = [[0,0]]
for i in range(len(coordenadas)-1):
    lista.append([])
#for i in mat:
    #print(i)
calcular_distancias_iniciales(mat, 0)
print(Dist)
diligencia(mat, 0)
print(Dist)
print(lista)
ordenar(lista)
