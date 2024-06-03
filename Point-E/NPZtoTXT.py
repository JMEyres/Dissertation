import numpy as np
from point_e.util.point_cloud import PointCloud

prompt = "Turret1"
pc = PointCloud.load("Pointclouds/"+prompt)
f = open(prompt+".txt", "w")

for i in pc.coords:
    j = np.array2string(i)
    f.write(j)
    f.write('\n')

f.close()



#f = open(prompt+ "_colors"+".txt", "w")
#for i in pc.channels.values():
#    j = np.array2string(i)
#   f.write(j)
#  f.write('\n')

#f.close()
