resource "hcloud_firewall" "database_firewall" {
  name = "${var.name}_firewall"
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "5432"
    protocol        = "tcp"
	description     = "Для запросов к серверу от backend"
    source_ips = [
      "10.0.1.2/32",
    ]
  }
}

resource "hcloud_server" "database_server" {
  name        = var.name
  image       = var.image
  server_type = var.server_type
  location    = var.location
  
  labels = {
    purpose : "database"
  }
  
  firewall_ids = [
    hcloud_firewall.database_firewall.id,
	var.base_firewall_id
  ]
  
  network {
    network_id = var.network_id
  }
}