from ortools.constraint_solver import pywrapcp
from ortools.constraint_solver import routing_enums_pb2
from time import time
import json
import math
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
def create_distance_callback(dist_matrix):
  # Create a callback to calculate distances between cities.
  def distance_callback(from_node, to_node):
    return (dist_matrix[from_node][to_node])

  return distance_callback
def calcular_peso(lat1,lon1,lat2,lon2):
    rad=math.pi/180
    dlat=lat2-lat1
    dlon=lon2-lon1
    R = 6372.795477598
    a = (math.sin(rad*dlat / 2))**2 + math.cos(rad * lat1) * math.cos(rad * lat2) * (math.sin(rad * dlon / 2)) **2;
    distancia = 2 * R * math.asin(math.sqrt(a))
    return distancia
def matriz(lista):
    matriz_distancia=[]
    for i in range(len(lista)):
        aux=[]
        for j in range(len(lista)):
            aux.append(round(calcular_peso(lista[i].lat,lista[i].lon,lista[j].lat,lista[j].lon)))
        matriz_distancia.append(aux)
    return matriz_distancia

def cargar_capitales(ruta,numero):#departamental 1,provincial 2, distrital 3
    with open(ruta, 'r', encoding='utf8', errors='ignore') as contenido:
        cont=0
        resultado=json.load(contenido)
        for i in resultado.get('features'):
            if i.get('properties').get('CAPITAL')==str(numero):
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
def constrant_programing(dist_matrix):
    nombre_de_ciudades=[]
    lon_ciudades=[]
    lat_ciudades=[]
    for i in coordenadas:
        nombre_de_ciudades.append(i.nombre)
        lon_ciudades.append(i.lon)
        lat_ciudades.append(i.lat)
    tamaño_tsp = len(nombre_de_ciudades)
    num_rutas = 1
    depot = 0

    # Creamos un modelo de enrutamiento
    if tamaño_tsp > 0:
        routing = pywrapcp.RoutingModel(tamaño_tsp, num_rutas, depot)
        search_parameters = pywrapcp.RoutingModel.DefaultSearchParameters()
        # Creamos la devolucion de la distancia.
        dist_callback = create_distance_callback(dist_matrix)
        routing.SetArcCostEvaluatorOfAllVehicles(dist_callback)
        # Se resuelve el problema.
        asignación = routing.SolveWithParameters(search_parameters)
        if asignación:
            # Solucion de la distancia
            print ("Distancia Total: " + str(asignación.ObjectiveValue()) + " Kilometros\n")
            # Muestra la solucion.
            # Only one route here; otherwise iterate from 0 to routing.vehicles() - 1
            route_number = 0
            index = routing.Start(route_number) # Index of the variable for the starting node.
            ruta = ''
            while not routing.IsEnd(index):
                # Convert variable indices to node indices in the displayed route.
                ruta_orden.append((str(lon_ciudades[routing.IndexToNode(index)]),str(lat_ciudades[routing.IndexToNode(index)])))
                ruta += str(nombre_de_ciudades[routing.IndexToNode(index)]) + ' -> '
                index = asignación.Value(routing.NextVar(index))
            ruta += str(nombre_de_ciudades[routing.IndexToNode(index)])
            ruta_orden.append((str(lon_ciudades[routing.IndexToNode(index)]),str(lat_ciudades[routing.IndexToNode(index)])))
            print ("Ruta:\n\n" + ruta)
        else:
            print ('Solucion no encontrada.')
    else:
        print ('Mejor instancia 0.')

ruta='Centros_Poblados.json'
numero=leer_Text()
cargar_capitales(ruta,numero)
t_inicial=time()
constrant_programing(matriz(coordenadas))
t_final=time()
t_total=t_final-t_inicial
print("Tiempo de ejecucion: %.10f sgundos." % t_total)
guardar()
