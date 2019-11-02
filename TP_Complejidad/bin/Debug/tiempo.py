from time import time


def count():
    for i in range(300):
        print(i)

t_inicial=time()
count()
t_final=time()
t_total=t_final-t_inicial
print("Tiempo de ejecucion: %.10f seconds." % t_total)
