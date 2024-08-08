//Exchange Nedir ?
// Publisher tarafından gönderilen mesajların nasıl yönetileceğini ve hangi route'lara gönderileceğini belirleyen bir yapıdır.
// Exchange, mesajları alır ve bir veya birden fazla kuyruğa yönlendirir.
// Route ise mesajların exchange üzerinden kuyruklara nsıl gönderğileceğini tanımlayan mekanizmadır.
// Routinge key ile mesajların hangi kuyruklara gönderileceği konusunda exchhange bilgi tutulur.
// Binding Nedir ?
// Exchange ve Queue arasındaki ilişkiyi belirler.Exchange ile kuyruk arasında bağlantı oluşturmanın terminolojik adıdır.
// Exchange Types 
// Direct Exchange : Mesajları routing key ile eşleşen kuyruklara gönderir.
// publisher -> exchange -> queue -> consumer
// routing key ."green" -> direct exchange -> queue -> consumer
// Genellikle hata mesajların işlendi senaryolarda kullanılabilir. Şöyle ki; bir sistemde dosya yükleme hatası , veritabanı hatası vs gibi farklı türde hata mesajları olabilir. Bu hata mesajların izlenmesi ve gerektiği taktirde çözülmesi gerekebiliri. Haliyele her bir hata türü için hususi ayrı bir kuyruk oluşturalabilir ve hata mesajları direk olarak ilgili kuyruğa yönlendirilebilir.

// Fanout Exchange : Mesajları tüm kuyruklara gönderir.
// publisher -> exchange -> queue1 -> consumer1
// publisher -> exchange -> queue2 -> consumer2
// Misal olarak ; bir microservice yaklaşımı benimsenmiş olan mimaride tüm servislere ortak bildirilerde bulunabilmek için fanout exchange kullanılabilir. Böyle veri paylaşımı merkezi bir şekilde hızlı ve etkili hale getirilebilir.

// Topic Exchange : Mesajları routing key ile eşleşen kuyruklara gönderir.
// Routing key'leri kullanarak  mesajları kuyruklara yönlendirmek için kullanılır. Bu exchange ile routing key'in bir kısmını keylere göre kuyruklara mesaj yönderir.

// Örnek olarak log sistemi senaryoları bu exchange için biçilmiş kaftan olacaktır.

// Headers Exchange : Mesajları header bilgileri ile eşleşen kuyruklara gönderir.
// Headers exchange, mesajları header bilgileri ile eşleşen kuyruklara yönlendirir. Bu exchange tipi, routing key ve binding key yerine header bilgileri ile eşleşme yapar. Bu sayede mesajları header bilgilerine göre kuyruklara yönlendirebiliriz.