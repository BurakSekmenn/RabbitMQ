// Mesaj tasarımlarından kastedilen Nedir ? 
// Mesaj tasarımlarından kastedilen, tıpkı design patternlerde olduğu gibi belli başlı senaryolara karşı gösterilebilecek önceden tanınlanmaış, tar,f edilmiş ve pratiksel olarak adımları saptanmış davranışlardır.
// Belirli bir problemi çözmek için kullanılan bu tasarımlar, genel anlamda yapısal davranışı ve iletişim modelini ifade etmektedir.
// Yani iki servis arasında message borker ile yapılacak haberleşme sürecinde iletilecek mesajların nasıl işleneceğini, ne şekilde yapılandırlacağını ve ne tür bilgiler taşıyağcaını belirler. 
// Her tasarım farklı bir uygulama senarysouna ve gereksinimine göre şekillinmekte ve en iyi sonuçlar alınabilecek şekilde yapılandırılmaktadır.
// Bu tasarımların en yaygın olanları şunlardır;
// 1- Point to Point (P2P)
// 2- Publish/Subscribe
// 3- Work Queue
// 4- Request/Response
// Bu tasarımların her biri farklı bir senaryoya karşı geliştirilmiş ve kullanılmaktadır.

// Point to Point (P2P) Mesaj Tasarımı
// Bu tasarım, bir mesajın sadece bir tane alıcı tarafından işlenmesini sağlar. Yani bir mesaj sadece bir tane alıcıya gönderilir ve bu alıcı tarafından işlenir.
// Gencay Hocanın notu; Bu tasarım'da bir publisher ilgili mesajı direk bir kuyruğa gönderir ve bu mesaj kuyruğu işleyen bir consumer tarafından tüketilir. Eğer bu senaryo gereği bir mesajın bir tüketici tarafından işlenmesi gerekiyorsa bu yaklaşım kullanılabilir.
// Publisher -> Queue -> Consumer


// Publish/Subscribe Mesaj Tasarımı
// Bu tasarım, bir mesajın birden fazla alıcı tarafından işlenmesini sağlar. Yani bir mesaj birden fazla alıcıya gönderilir ve bu alıcılar tarafından işlenir.

// Work Queue Mesaj Tasarımı    
// Bu tasarım, bir mesajın birden fazla alıcı(consumer) tarafından işlenmesini sağlar. Yani bir mesaj birden fazla alıcıya gönderilir ve bu alıcılar tarafından işlenir.
// publisher -> Queue1 -> Consumer1
// publisher -> Queue1 -> Consumer2
// publisher -> Queue1 -> Consumer3
// Önemli Bir Not; Work Queue tasarımı , yükünün dağıtılması gereken ve paralel işleme ihtayacı duyulan senaryolar için oldukça uygun bir tasarımdır.

// Request/Response Mesaj Tasarımı
// Bu tasarım, bir mesajın bir alıcı tarafından işlenmesini ve bu alıcı tarafından bir yanıtın gönderilmesini sağlar. Yani bir mesaj bir alıcıya gönderilir ve bu alıcı tarafından işlenir. Daha sonra bu alıcı, bir yanıt mesajı gönderir.