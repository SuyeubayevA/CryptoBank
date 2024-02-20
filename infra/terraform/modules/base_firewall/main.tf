resource "hcloud_firewall" "base_firewall_rules" {
  name = "base_firewall"
  
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
}