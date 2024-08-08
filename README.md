🚀 RabbitMQ Üzerine Çalışmalarım
Bu proje, RabbitMQ'yu derinlemesine öğrenmek ve farklı kullanım senaryolarını incelemek amacıyla oluşturulmuştur. Aşağıdaki konular üzerinde çalıştım:

📜 Exchange Types
RabbitMQ, mesajları belirli kurallara göre yönlendirmek için çeşitli exchange türleri sunar:
-- Direct: Belirli routing key ile mesaj yönlendirme.
-- Fanout: Tüm kuyruklara mesaj yayınlama.
-- Topic: Dinamik routing key ile mesaj yönlendirme.
-- Header: Mesaj başlıklarına göre yönlendirme.

🎨 Mesaj Tasarım Desenleri
Mesajlaşma sistemlerinde yaygın olarak kullanılan tasarım desenlerini araştırdım:
-- Command Pattern
-- Event-Driven Architecture
-- Request-Reply Pattern

🛠️ Message Durability ve Fair Dispatch
Mesajların kaybolmaması ve adil dağıtımı için neler yapılabileceğini inceledim:
-- Durable Queues
-- Persistent Messages
-- Round-Robin Dispatch

✔️ Acknowledge Message

Mesajların başarılı bir şekilde alındığını doğrulamak için kullanılan acknowledge (onaylama) mekanizmasını araştırdım:
-- Auto Acknowledge
-- Manual Acknowledge
-- Negative Acknowledgement (Nack)

🏢 Enterprise Service Bus (ESB)

Büyük ölçekli ve karmaşık sistemlerde RabbitMQ'nun ESB olarak nasıl kullanılabileceğini inceledim:
-- Service Oriented Architecture (SOA)
-- Microservices Integration

📚 MassTransit

MassTransit kütüphanesini kullanarak RabbitMQ ile nasıl etkileşime geçileceğini öğrendim:
-- Configuration and Setup
-- Publish-Subscribe Patterns
-- Saga Management
Kaynak: Gencay Yıldız - YouTube (RabbitMQ Eğitimi)
