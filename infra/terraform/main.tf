provider "hcloud" {
  token = var.hcloud_token
}

resource "hcloud_network" "h_network" {
  name     = "my_net"
  ip_range = "10.0.0.0/16"
}

resource "hcloud_network_subnet" "h_subnet" {
  network_id   = hcloud_network.h_network.id
  type         = "cloud"
  network_zone = "eu-central"
  ip_range     = "10.0.1.0/24"
}