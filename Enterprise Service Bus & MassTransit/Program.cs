// Enterprise Service Bus & MassTransit Notlar
// Enterprise Service Bus (ESB) Nedir ?
// Esb, servisler arası entagrasyonu sağlayan komponentlerin bütünüdür diyebiliriz. Yani farklı yazılım sistemleri birbirleriyle iletişim kurmasını sağlamak için kullanılan bir yazılım mimarisi ve araç setidir. Burada şöyle bir örnek üzerinden devam edebilriz RabbitMQ farklı sistemler arasında bir iletişim modeli ortaya koymamızı sağlayan teknolojidir. RabbitMQ gibi farklı sistemlerin birbirleriyle etkileişme girmesini sağlayan teknolojilerin kullanımını ve yönetilebilirliğini kolaylaştırmakta ve buna bir ortam sağlamatadır.
// Esb, servisler arası etkilişim süreçlerinde aracı uygulamarada karşın yüksek bir abstraction görevi görmekte ve böylece bütünsel olarak sistemin tek bir teknolojiye bağımlı olmasını engelemektedir.
// Bu da, bu gün rabbitMQ teknolojisi tasarlanan bir sistemin yarın ihtiyaç doğrultusunda kafka vs gibi farklı message broker'a geçişini kolaylaştırmaktadır.

// Esb'nin Temel Amacı Nedir ? 
// Farklı uygulamarın servislerini sistemlerini birbirleriyle kolayca iletişim kurulabilmesi sağlamaktadır.


// MassTransit Nedir ?
// MassTransit, .NET platformu için geliştirilmiş bir open source mesajlaşma kütüphanesidir.

// Transport Gateway Nedir ?
// Transport Gateway, farklı sistemler arasında farklı iletişim protokllerini kullnarak sistemler arasında iletişim kurmayı sağlayan bir araçtır. 
// Bu araç: iletişim protokllerindeki farklılıkları gidererek sistemler arasında iletişim kurmayı sağlar.