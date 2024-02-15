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

module "backend" {
	source = "./modules/api-server"
	
	name = "backend"
	location = "test1"
	server_type = "cx21"
	image = "ubuntu-22.04"
	network_id = hcloud_network.h_network.id
}

module "frontend" {
	source = "./modules/client-server"
	
	name = "frontend"
	location = "test2"
	server_type = "cx21"
	image = "ubuntu-22.04"
	network_id = hcloud_network.h_network.id
}

module "database" {
	source = "./modules/db-server"
	
	name = "database"
	location = "test3"
	server_type = "cx21"
	image = "ubuntu-22.04"
	network_id = hcloud_network.h_network.id
}

resource "hcloud_load_balancer" "load_balancer" {
  name               = "my-load-balancer"
  load_balancer_type = "lb11"
  location           = "nbg1"
}

resource "hcloud_load_balancer_target" "load_balancer_target_1" {
  type             = "server"
  load_balancer_id = hcloud_load_balancer.load_balancer.id
  server_id        = module.backend.id
}

resource "hcloud_load_balancer_target" "load_balancer_target_2" {
  type             = "server"
  load_balancer_id = hcloud_load_balancer.load_balancer.id
  server_id        = module.frontend.id
}