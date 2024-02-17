resource "hcloud_firewall" "database_firewall" {
  name = "${var.name}_firewall"
  
   rule {
    destination_ips = []
    direction       = "in"
    port            = "22"
    protocol        = "tcp"
	description     = "Для SSH подключений к серверу"
    source_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "53"
    protocol        = "tcp"
	description     = "Для DNS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "53"
    protocol        = "udp"
	description     = "Для DNS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "80"
    protocol        = "tcp"
	description     = "Для HTTP запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "80"
    protocol        = "udp"
	description     = "Для HTTP запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "443"
    protocol        = "tcp"
	description     = "Для HTTPS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "443"
    protocol        = "udp"
	description     = "Для HTTPS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
    ]
  }
  
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
  
  network {
    network_id = var.network_id
  }
}