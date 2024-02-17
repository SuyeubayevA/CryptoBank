resource "hcloud_firewall" "api_firewall" {
  name = "${var.name}_firewall"
  
   rule {
    destination_ips = []
    direction       = "in"
    port            = "22"
    protocol        = "tcp"
	description     = "Для SSH подключений к серверу"
    source_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "53"
    protocol        = "tcp"
	description     = "Для DNS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "53"
    protocol        = "udp"
	description     = "Для DNS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "80"
    protocol        = "tcp"
	description     = "Для HTTP запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "80"
    protocol        = "udp"
	description     = "Для HTTP запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "443"
    protocol        = "tcp"
	description     = "Для HTTPS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }

  rule {
    direction       = "out"
    port            = "443"
    protocol        = "udp"
	description     = "Для HTTPS запросов из сервера"
    destination_ips = [
      "0.0.0.0/0",
      "::/0",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "80"
    protocol        = "tcp"
	description     = "Для HTTP запросов к серверу от frontend"
    source_ips = [
      "10.0.1.1/32",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "80"
    protocol        = "udp"
	description     = "Для HTTP запросов к серверу от frontend"
    source_ips = [
      "10.0.1.1/32",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "443"
    protocol        = "tcp"
	description     = "Для HTTPS запросов к серверу от frontend"
    source_ips = [
      "10.0.1.1/32",
    ]
  }
  
  rule {
    destination_ips = []
    direction       = "in"
    port            = "443"
    protocol        = "udp"
	description     = "Для HTTPS запросов к серверу от frontend"
    source_ips = [
      "10.0.1.1/32",
    ]
  }
  
  rule {
	direction       = "out"
    port            = "5432"
    protocol        = "tcp"
	description     = "Для запросов к database из сервера"
    destination_ips = [
      "10.0.1.1/32",
    ]
  }
}

resource "hcloud_server" "backend_server" {
  name        = var.name
  image       = var.image
  server_type = var.server_type
  location    = var.location
  
  labels = {
    purpose : "backend"
  }
  
  firewall_ids = [
    hcloud_firewall.api_firewall.id
  ]
  
  network {
    network_id = var.network_id
  }
}