import numpy
import matplotlib.pyplot as plt
import torch
import numpy
from tqdm.auto import tqdm

from point_e.diffusion.configs import DIFFUSION_CONFIGS, diffusion_from_config
from point_e.diffusion.sampler import PointCloudSampler
from point_e.models.download import load_checkpoint
from point_e.models.configs import MODEL_CONFIGS, model_from_config
from point_e.util.plotting import plot_point_cloud
from point_e.util.point_cloud import PointCloud

pc = PointCloud.load("Pointclouds/futuristic building")

fig = plot_point_cloud(pc, grid_size=3, fixed_bounds=((-1, -1, -1), (1, 1, 1)))

plt.show()
