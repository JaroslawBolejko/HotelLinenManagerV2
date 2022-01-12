# HotelLinenManagerV2
Project under development. Beta version available at https://hotellinenmanagerbeta.azurewebsites.net/ .
It is designed for larger screens.
Client-side is made in Blazor WASM with Syncfusion components.
Server-side is a RESTful API with Asp.net Core Web API.
Back-end contains CQRS and Mediator patterns and it use FluentValidator, Auto-Maper and EntityFramework Core 5. It is connected with API REGON - 
polish main statistical office API that allows to download companies data by their tax number. 

Application is made for hotels and their laundires. The perfect scenario assumes that both(laundry and hotel) use it. It can be used only by one side but then capabilities are much smaller. 


If you are a new hotel user please fallow the steps:

1.Create two, new warehauses. It has to be "Magazyn_Czystej_Poscieli" and "Magazyn_Brudnej_Poscieli".
2.If you have clean linen warehause, then you have to create new hotel linen items. (By default they will be stored in clean linen warehause).
3.In Companies please add your laundry(related company). You must input real, valid, polish tax number(NIP). It is necessary to create laundry-service.
4.Add your laundry price list, and edit it. IsCurrent have to be set to true, by default it is false. It is necessary to calculate laundry service value.
5.Laundry service is created by moving hotel linen items from dirty linen warehause to the laundry. There is a button for it.

If you are a new laundry user please fallow the steps:

1.Add your clients to realted companies.You must input real,valid, polish tax number(NIP).
2.Create a price list for your client and edit it. IsCurrent have to be set to true, by default it is false.
3.If you have clients and their laundry services you can create invoices for them.

Only hotel user can close the laundry service. Only Laundry user can create an invoice.

If you don't want to register new companies, you can use:
-Laundry User : login : jan@kowalski.pl , password: kowalski;
-Hotel User : login : piotr@nowak, password: nowak;


