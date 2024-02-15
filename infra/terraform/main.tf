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

module "api_server_1" {
	source = "./modules/api-server"
	
	name = "test"
	location = "test1"
	server_type = "cx21"
	image = "ubuntu-22.04"
	network_id = hcloud_network.h_network.id
}

module "api_server_2" {
	source = "./modules/api-server"
	
	name = "test2"
	location = "test2"
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
  server_id        = module.api_server_1.id
}

resource "hcloud_load_balancer_target" "load_balancer_target_2" {
  type             = "server"
  load_balancer_id = hcloud_load_balancer.load_balancer.id
  server_id        = module.api_server_2.id
}