import torch.nn.functional as F
from torch_geometric.nn import GCNConv

import torch

import warnings
warnings.filterwarnings('ignore')


class GAE(torch.nn.Module):
    def __init__(self, in_channels, out_channels):
        super(GAE, self).__init__()
        self.conv1 = GCNConv(in_channels, 2 * out_channels)
        self.conv2 = GCNConv(2 * out_channels, out_channels)

    def encode(self, x, edge_index, edge_weight):
        x = F.relu(self.conv1(x, edge_index, edge_weight))
        return self.conv2(x, edge_index, edge_weight)

    def decode(self, z, pos_edge_index, neg_edge_index):
        pos_pred = (z[pos_edge_index[0].long()] * z[pos_edge_index[1].long()]).sum(dim=1)
        neg_pred = (z[neg_edge_index[0].long()] * z[neg_edge_index[1].long()]).sum(dim=1)
        return pos_pred, neg_pred

    def forward(self, data):
        z = self.encode(data.x, data.train_pos_edge_index, data.train_pos_edge_weight)
        return z
