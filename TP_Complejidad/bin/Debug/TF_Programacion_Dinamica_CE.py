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

def cargar_distrito(ruta,lugar):#departamental 1,provincial 2, distrital 3
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('NOMCPSIG')==str(lugar) :
                nuevo=Nodo(i.get('properties').get('CLONG_IE_D'),i.get('properties').get('CLAT_IE_DE'),i.get('properties').get('CEN_EDU'))
                coordenadas.append(nuevo)
                #print(cont," ",coordenadas[cont].nombre,"\t Lon: ",coordenadas[cont].lon," La: ",coordenadas[cont].lat)
                #input()
                cont+=1
def cargar_region_lima(ruta):#departamental 1,provincial 2, distrital 3
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('DRE_UGEL')=="DRE LIMA PROVINCIAS" or i.get('properties').get('DRE_UGEL')=="DRE LIMA METROPOLITANA":
                nuevo=Nodo(i.get('properties').get('CLONG_IE_D'),i.get('properties').get('CLAT_IE_DE'),i.get('properties').get('CEN_EDU'))
                coordenadas.append(nuevo)
                #print(cont," ",coordenadas[cont].nombre,"\t Lon: ",coordenadas[cont].lon," La: ",coordenadas[cont].lat)
                #input()
                cont+=1
def cargar_region_piura(ruta):#departamental 1,provincial 2, distrital 3
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('DRE_UGEL')=="PIURA":
                nuevo=Nodo(i.get('properties').get('CLONG_IE_D'),i.get('properties').get('CLAT_IE_DE'),i.get('properties').get('CEN_EDU'))
                coordenadas.append(nuevo)
                #print(cont," ",coordenadas[cont].nombre,"\t Lon: ",coordenadas[cont].lon," La: ",coordenadas[cont].lat)
                #input()
                cont+=1
def que_cargar(ruta,numero):
    if(numero==str("1")):
        cargar_distrito(ruta,"SANTIAGO DE SURCO")
    elif(numero==str("2")):
        cargar_region_lima(ruta)
    elif(numero==str("3")):
        cargar_region_piura(ruta)
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
def ruta_mas_corta(G,origen,visitados):
    if(len(visitados)<len(G)):
        dest=math.inf
        menor=math.inf
        for j in range(len(G)):
            if (origen!=j):
                if(menor>G[origen][j] and (j not in visitados)):
                    menor=G[origen][j]
                    dest=j
        visitados.append(dest)
        ruta_mas_corta(G,dest,visitados)            
            
     
   
#Nombre el archivo   
ruta='Centros_Educativos.json'
#Sacan los datos del archivo
numero=leer_Text()
que_cargar(ruta,numero)
#Se convierte en una matriz
mat=matriz(coordenadas)
t_inicial=time()
p, d = floydwarshall(mat)
#for i in range(len(p)):
 #   print(d[i])
visitados=[]
origen=0



visitados.append(origen)
ruta_mas_corta(d,origen,visitados)
#print("ready")
visitados.append(origen)

t_final=time()
t_total=t_final-t_inicial
print("Tiempo de ejecucion: %.10f sgundos." % t_total)

input()
print(visitados)
guardar(visitados)
