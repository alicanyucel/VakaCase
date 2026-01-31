# VakaCase (.NET 8)

Bu repo, **.NET 8 / ASP.NET Core Web API uzerinde kurgulanmis ornek bir uygulamadir. Mimari olarak **Domain / Application / Infrastructure / WebAPI** katmanlari ayrilmistir ve istekler **MediatR (CQRS)** ile islenir.

## Proje Yapýsý

- `VakaCase.Domain`: Entity'ler ve repository arayuzleri.
- `VakaCase.Application`: Use-case'ler (Command/Query), handler'lar, validasyon ve mapping.
- `VakaCase.Infrastructure`: EF Core `DbContext`, repository implementasyonlari, migrations.
- `VakaCase.WebAPI`: HTTP API (controller'lar), middleware'ler ve konfigurasyon.

## Gereksinimler

- .NET SDK **8.0+**
- (Varsa) Docker Desktop

## Kurulum

### 1) Projeyi çalýþtýrma

Solution klasöründe:

```bash
dotnet restore
dotnet build
dotnet run --project VakaCase/VakaCase.WebAPI
```

Uygulama ayaða kalktýktan sonra Swagger arayüzü genellikle þu adreste olur:

- `https://localhost:<port>/swagger`

> Port bilgisi `VakaCase/VakaCase.WebAPI/Properties/launchSettings.json` veya konsol çýktýsýndan görülebilir.

### 2) Ortam deðiþkenleri

`VakaCase/VakaCase.WebAPI/.env` içinde ortam deðiþkenleri bulunur. Gerekirse connection string ve JWT ayarlarýný buradan güncelleyebilirsiniz.

## API Kullanýmý

Bu projede `ApiController` route þablonu þu þekildedir:

- `api/[controller]/[action]`

Cihaz islemleri icin endpoint'ler (tamami **POST**):

- `POST /api/Devices/GetById`
- `POST /api/Devices/Create`
- `POST /api/Devices/Update`
- `POST /api/Devices/Delete`
- `POST /api/Devices/GetAll`

### Ornek Istekler

#### 1) GetAll

```http
POST /api/Devices/GetAll
Content-Type: application/json

{}
```

#### 2) GetById

```http
POST /api/Devices/GetById
Content-Type: application/json

{
  "id": "00000000-0000-0000-0000-000000000000"
}
```

#### 3) Create

```http
POST /api/Devices/Create
Content-Type: application/json

{
  "name": "Cihaz 1",
  "serialNumber": "SN-001",
  "isActive": true,
  "lastMaintenanceDate": "2026-01-01T00:00:00Z",
  "isDeleted": false
}
```

#### 4) Update

```http
POST /api/Devices/Update
Content-Type: application/json

{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Cihaz 1 (Güncel)",
  "serialNumber": "SN-001",
  "isActive": true,
  "lastMaintenanceDate": "2026-01-15T00:00:00Z",
  "isDeleted": false
}
```

#### 5) Delete

```http
POST /api/Devices/Delete
Content-Type: application/json

{
  "id": "00000000-0000-0000-0000-000000000000"
}
```

## Response Formatý

Baþarýlý iþlemlerde controller tarafý kullanýcý-dostu Türkçe mesaj döndürür:

- `message`: Ýþlem sonucu mesajý
- `data`: (varsa) handler'dan donen veri

Örn:

```json
{
  "message": "Cihaz baþarýyla oluþturuldu.",
  "data": "..."
}
```

## Notlar

- Dogrulama (validation) hatalari FluentValidation altyapisi uzerinden yonetilir.
- Hata yakalama/cevaplama davranisi icin `VakaCase.WebAPI/Middlewares` klasorune bakabilirsiniz.

## Lisans

Bu repo örnek çalýþma amaçlýdýr.
