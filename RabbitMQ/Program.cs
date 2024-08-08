//************************************************************************************************
//RabbitMQ Hakkında ders notu
//************************************************************************************************


//RabbitMQ 

// Message Queue Nedir ?
// Message Queue, bir mesajın bir uygulamadan diğerine iletilmesini sağlayan bir iletişim protokolüdür.
// Birbirinden bağımsız sistemler arasında veri alışveri yapmak için kullanılır.
// Message Queue gönderilen mesajları kuyrukta saklar ve sonra bu mesajların işlenmesini sağlar.
// Kuyruğa mesaj gönderene üretici (producer) yada publisher denir. Kuyruktan mesaj alan ise tüketici (consumer) olarak adlandırılır.
// Message Queue, sistemler arasında asenkron mesajlaşma sağlar. Bu sayede sistemler birbirinden bağımsız çalışabilir.
// Message Queue, sistemler arasında iletişimde kullanılan bir araçtır. Bu sayede sistemler arasında bağlantı kopuk olsa bile mesajlar kuyrukta saklanır ve işlenir.

// RabbitMQ Nedir ?
// Open source olan bir message queue yazılımıdır. AMQP (Advanced Message Queuing Protocol) protokolünü destekler.
// Cloud'da hizmeti mevcuttur. (RabbitMQ Cloud)
// Zengin bir dokümantasyona sahiptir.
// RabbitMQ, Neden Kullanmalıyız ? 
// Uygulamalarımızda kullanıcılardan gelen isteklerin neticilerinde anlık cevap veremiyorsak ya da anlık olmayan/zaman oalan işlemleri devreye sokmamız gerekiyorsa kullanıcıya oyalamak yerine bu tarz süreçleri asenkron bir şekilde işleyip uygulamamızı yoğunluğunu düşürmemez gerekmetedir.
// RabbitMQ , response time'ı uzun sürebilecek operasyonların uygulamadan bağımsızlarştırarka buradaki sorumluluğu farklı bir uygulamanın üstenmesini sağlar.
