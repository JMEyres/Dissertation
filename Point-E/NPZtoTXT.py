import numpy as np
from point_e.util.point_cloud import PointCloud

prompt = "Photocopier"
pc = PointCloud.load("Pointclouds/"+prompt)
f = open("PCtxtFiles/"+prompt+".txt", "w")

for i in pc.coords:
    j = np.array2string(i)
    f.write(j)
    f.write('\n')

f.close()