// Gelişmiş Kuyruk Mimarisi
//Gelişmiş Kuyruk Mimarisi Ders Notu

// Ders Notları
// RabbitMq teknolojisini ana fikri, yoğun kaynak gerektiren işleri/görevleri/operasyonları hemen yapmaya koyularak tamamlanmasını beklmek zorunda kalmaksızın, bu işleri ölçeklendirilebilir bir vaziyette daha sonra yapılacak şekilde planlamaktır.
// Tabi bu planlamayı gerçekleştirirken kuyruklardan istifade edilmekte ve görevleri temsil edecek olan mesajlar bu kuyruklara atılmakta ve tüketiciler tarafından bu mesajlar elde edilerek görevlerin asenkron bir şekilde işlenmesi sağlanmaktadır.

// Round-Robin Dispatching Sıralı Gönderim
// RabbitMQ, default olarak tüm consumer'lara sırasıyla mesaj gönderir

//************************************************************************
// Message Acknowledgement
//************************************************************************

// Message Acknowledgement Mesaj Onayı özelliğidir.
// Şöyle Bir örnek verebiliriz, Bir e-ticaret sitesi düşün günlük 100 sipariş alıyorsun ama sistemde 80 sipariş var burada bir veri kaybı özelliği var biz bu veri kaybını önlemek için mesaj onayı özelliğini kullanırız. İşlem onaylandında rabbitmq geri dönüş sağlarız bu işlem tamamlandı diye. Eğer işlem tamamlanmazsa rabbitmq işlemi tekrar gönderir ve işlem tamamlanana kadar tekrar tekrar gönderir. Bu sayede veri kaybını önlemiş oluruz.
// Gencay Hocanın Notu;
// RabbitMq, tüketiciye gönderdiği mesajı başarılı bir şekilde işlensin veya işlenmesin hemen kuryuktan silinmesi üzeri işaretler.
// Tüketici kuyruktan aldıkları mesajları işlemleri sürecinde herhangi bir kesinti yahut problem durumu meydana gelirse ilgili mesaj tam olarak işleneyeceği için esasında görev tamamlanmamış olacaktır. Bu tarz durumlara istinaden mesaj başarıyla işendiyse eğer kuyrutan silinmesi için tüketiciden RabbitMQ'nun uyarılması gerekmektedir.

// Önemli Bir Not !!!
// Bir mesajı consumarda işlem başarılı olduğu taktirde kuyruğa bildirmesin bu işlem tekrardan kuyruğa girer buda bize veri kaybı yaşatır. Bu yüzden işlem başarılı olduğunda kuyruğa bildirme işlemi yapmamalıyız. Örnek olarak -> 100 sipariş aldığın bir sistemde consumerda bu veri döndürmesen gün sonu bakmışsın 110 sipariş var consumrdan tekrar kuyruğa eklenmiş. Bu yüzden işlem başarılı olduğunda kuyruğa bildirme işlemi yapmamalıyız.!!!!
//Gencay Hoca Message Acknowledgement Diar Son iştişareler.
// Anlayacağınız bu özellik sayesinde bir mesajın kaybolmadığınında emin olabilmekteyiz. Tüketici mesajı işlediğinde RabbitMQ'ya mesajın işlendiğini bildirir ve bu mesajın kuyruktan silinmesini sağlar. Eğer tüketici mesajı işleyemezse, RabbitMQ mesajı tekrar kuyruğa ekler ve tekrar işlenmesini sağlar. Bu sayede mesajların kaybolmasını engellemiş oluruz. 
// Eğer sen yapmadıysa rabbitMq 30 dkk sonra tekrardan sıraya koyar işlemini consumerda geri dönüş yapmadıysan.
// Consumer mesaj başarıyla işlendiğine dair uyarıyı basicAsk Metodu ile gerçekleştirir.



// BasicNack ile işlenmeyen Mesajları Geri Gönderme
// Gencay Hoca Notu;
// Bazen, consumerlar da istemsiz durumların dışında kendi kontrollerimiz neticisinden mesajları işlememek isteyebilir veyahut ilgili mesajın işlenmesini başarıyla sonuçlandıramyacağımız anlayabiliriz. Böyle durumlarda 'channel.BasicNack' metotunu kullanarak RabbitMQ'ya bilgi verebilir ve mesajı tekrardan işletebiliriz. Tabi burada requeue paramatresi olduça önem arz etmektedir. Bu parametre, bu consumer tarafından işleneyeceği ifade edilen bu mesajın tekrardan kuyruğa eklenip eklenmemsi kararnı vermektedir.Ama veri kaybı yaşanabilir.


//************************************************************************
//Message Durability Notu
//************************************************************************


//Message Durability Mesaj Dayanıklılığı
// Gencay Hoca Notu;
// Consumr'ların sıkıntı yaşama durumunda mesajların kaybolmayacağının garantisini nasıl sağlanayacak öğrenmiş olduk. Ancak RabbitMQ sunucusunda bir zeval uğraması durumda ne olacağı konuşmamız gerekiyor. Evet RabbitMQ sunucusunda bir problem meydana geldiğinde yahut kapandığında gg :D , RabbitMq normal şartlarda bir kapanma durumu söz konusu olursa tüm kuyruklar ve mesajlar silenecektir ! böyle bir durumda mesajların kaybalmaması için yani kalıcı olabilmesi içn ekstradan çalışma gerçekleştirme gerekmetedir. Bu çalışma kuyruk ve mesaj açısından kalıcı olarak işaretleme yapmamız gerkemektedir. Örneği Publisher Kısmında var.


//************************************************************************
// Fair dispatching Notu
//************************************************************************

// Fair Dispatching Adil Gönderim
// Burada consumerlara eşit bir şekilde iş gönderimi yapabiliriz artık kaç tane varsa ise örnek kodu var bakabilirisin.