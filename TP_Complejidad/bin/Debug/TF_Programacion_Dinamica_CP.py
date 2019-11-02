import json
import math
from operator import itemgetter
from time import time
global Dist
lista=[]
class Nodo:
    def __init__(self,X,Y,N):
        self.lon=X
        self.lat=Y
        self.nombre=N
coordenadas=[]
ruta_orden=[]
def leer_Text():
    UNO_CERO=""
    archivo = open("Text.txt", 'r')
    for linea in archivo.readlines():
        for i in range(1):
            UNO_CERO = str(linea[i])
    archivo.close()
    return UNO_CERO
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
                aux.append((j,calcular_peso(lista[i].lat,lista[i].lon,lista[j].lat,lista[j].lon)))
        matriz_distancia.append(aux)
    menor=math.inf
    aux2=[]
    for v,w in matriz_distancia[0]:
        if(w<menor):
            aux2=[(v,w)]
            menor=w
    matriz_distancia[0]=aux2
    return matriz_distancia
     

def floydwarshall(G):
    n=len(G)
    d = [[math.inf]*n for _ in range(n)]
    p = [[-1]*n for _ in range(n)]
    for u in range(n):
        d[u][u]=0
        for v,w in G[u]:
            d[u][v]=w
            p[u][v]=u
    for k in range(n):
        for i in range(n):
            for j in range(n):
                f= d[i][k] + d[k][j]
                if d[i][j] >f:
                    d[i][j] = f
                    p[i][j] = k
        
    return p, d
def guardar(ruta_orden):
    mi_path = "Ciudades.txt"
    f = open(mi_path, 'w')
    for i in ruta_orden:
        linea=str(coordenadas[i].lon)+"\n"+str(coordenadas[i].lat)+"\n"
        f.write(linea)
    f.close()
def ruta_mas_corta(G,origen,visitados,s):
    if(len(visitados)<len(G)):
        dest=math.inf
        menor=math.inf
        for j in range(len(G)):
            if (origen!=j):
                if(menor>G[origen][j] and (j not in visitados)):
                    menor=G[origen][j]
                    dest=j
        visitados.append(dest)
        s+=menor
        #print("suma",s)
        ruta_mas_corta(G,dest,visitados,s)            
            
        

#Nombre el archivo   
ruta='Centros_Poblados.json'
#Sacan los datos del archivo
numero=leer_Text()
cargar_capitales(ruta,numero)
#Se convierte en una matriz
mat=matriz(coordenadas)
t_inicial=time()
p, d = floydwarshall(mat)
#for i in range(len(p)):
 #   print(d[i])
visitados=[]
origen=9

s=0

visitados.append(origen)
ruta_mas_corta(d,origen,visitados,s)
#print("ready")
visitados.append(origen)
#print("ruta: " , s)
t_final=time()
t_total=t_final-t_inicial
print("Tiempo de ejecucion: %.10f sgundos." % t_total)

input()
print(visitados)
guardar(visitados)
#for i in mat:
 #   print(i)
#calcular_distancias_iniciales(mat, 0)
#Programacion_Dinamica(mat, 0)
