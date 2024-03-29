resource "hcloud_firewall" "client_firewall" {
  name = "${var.name}_firewall"

  rule {
    destination_ips = []
    direction       = "in"
    port            = "80"
    protocol        = "tcp"
	description     = "Для HTTP запросов к серверу"
    source_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "80"
    protocol        = "udp"
	description     = "Для HTTP запросов к серверу"
    source_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "443"
    protocol        = "tcp"
	description     = "Для HTTPS запросов к серверу"
    source_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "443"
    protocol        = "udp"
	description     = "Для HTTPS запросов к серверу"
    source_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }
}

resource "hcloud_server" "frontend_server" {
  name        = var.name
  image       = var.image
  server_type = var.server_type
  location    = var.location
  
  labels = {
    purpose : "frontend"
  }
  
  firewall_ids = [
    hcloud_firewall.client_firewall.id,
	var.base_firewall_id
  ]
  
  network {
    network_id = var.network_id
  }
}