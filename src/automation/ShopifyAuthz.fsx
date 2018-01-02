// get the hmac-sha256 key from azure key vault
// use it to compute the HMAC digest with SHA256
// hmac means message authentication code
// get this out of the headers"," X-Shopify-Hmac-SHA256, this is what must match
// get the app secret, use the app secret to hash the message body
// compare that hash with the header hash

#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data
open System.Net

let helper_get_request() = 
    // load the sample request 
    let result = Http.RequestString (
                    "https://ms-shopify-ordercreation.azurewebsites.net/api/HttpTriggerFSharp1?code=2h8OJx4PXxs92xwuiobCi1aTtI/7NvVaHa9vYsaZLiYO1CjRmbt1yA==", 
                    httpMethod="POST",
                    headers = [ "Cf-Ray","35cba8a4b3270f33-IAD";
                        "Accept","*/*";
                        "X-Request-Id","b70a5833-c173-481a-9a3a-d6106992d824";
                        "Cf-Connecting-Ip","23.227.55.125";
                        "Host","requestb.in";
                        "X-Shopify-Hmac-Sha256","h/zmxqrEn63hobKhOu3D2Gezpj6wR9cO3L3p3K9Bv50=";
                        "Connection","close";
                        "Cf-Ipcountry","CA";
                        "X-Shopify-Topic","orders/create";
                        "X-Newrelic-Transaction","PxRRVFRXDgdVBgJXVgZSVlVUFB8EBw8RVU4aBA0KAAQHAFsCBAAEB1QHUkNKQQlWCFxRAQNXFTs=";
                        "Connect-Time","5";
                        "Accept-Encoding","gzip";
                        "Content-Type","application/json";
                        "User-Agent","Ruby";
                        "X-Shopify-Shop-Domain","meadowsweet-posies.myshopify.com";
                        "X-Shopify-Order-Id","820982911946154508";
                        "X-Shopify-Test","true";
                        "Cf-Visitor","""{""scheme"",""http""}""";
                        "Total-Route-Time","0";
                        "Via","1.1 vegur";
                        "Content-Length","3729";
                        "X-Newrelic-Id","VQQUUFNS"
            ],
                    body = TextRequest """{
                "id": 820982911946154500,
                "email": "jon@doe.ca",
                "closed_at": null,
                "created_at": "2017-05-10T04:51:48-04:00",
                "updated_at": "2017-05-10T04:51:48-04:00",
                "number": 234,
                "note": null,
                "token": "123456abcd",
                "gateway": null,
                "test": true,
                "total_price": "28.90",
                "subtotal_price": "18.90",
                "total_weight": 0,
                "total_tax": "0.00",
                "taxes_included": false,
                "currency": "USD",
                "financial_status": "voided",
                "confirmed": false,
                "total_discounts": "5.00",
                "total_line_items_price": "23.90",
                "cart_token": null,
                "buyer_accepts_marketing": true,
                "name": "#9999",
                "referring_site": null,
                "landing_site": null,
                "cancelled_at": "2017-05-10T04:51:48-04:00",
                "cancel_reason": "customer",
                "total_price_usd": null,
                "checkout_token": null,
                "reference": null,
                "user_id": null,
                "location_id": null,
                "source_identifier": null,
                "source_url": null,
                "processed_at": null,
                "device_id": null,
                "phone": null,
                "browser_ip": null,
                "landing_site_ref": null,
                "order_number": 1234,
                "discount_codes": [],
                "note_attributes": [],
                "payment_gateway_names": [
                    "visa",
                    "bogus"
                ],
                "processing_method": "",
                "checkout_id": null,
                "source_name": "web",
                "fulfillment_status": "pending",
                "tax_lines": [],
                "tags": "",
                "contact_email": "jon@doe.ca",
                "order_status_url": null,
                "line_items": [
                    {
                        "id": 866550311766439000,
                        "variant_id": null,
                        "title": "Posies Every Week",
                        "quantity": 1,
                        "price": "10.95",
                        "grams": 1000,
                        "sku": "pos_wk1",
                        "variant_title": null,
                        "vendor": null,
                        "fulfillment_service": "manual",
                        "product_id": 7368666823,
                        "requires_shipping": true,
                        "taxable": true,
                        "gift_card": false,
                        "name": "Posies Every Week",
                        "variant_inventory_management": null,
                        "properties": [],
                        "product_exists": true,
                        "fulfillable_quantity": 1,
                        "total_discount": "0.00",
                        "fulfillment_status": null,
                        "tax_lines": []
                    },
                    {
                        "id": 141249953214522980,
                        "variant_id": null,
                        "title": "Posies Monthly  Auto renew",
                        "quantity": 1,
                        "price": "12.95",
                        "grams": 1000,
                        "sku": "pos_wk4",
                        "variant_title": null,
                        "vendor": null,
                        "fulfillment_service": "manual",
                        "product_id": 10035437767,
                        "requires_shipping": true,
                        "taxable": true,
                        "gift_card": false,
                        "name": "Posies Monthly  Auto renew",
                        "variant_inventory_management": null,
                        "properties": [],
                        "product_exists": true,
                        "fulfillable_quantity": 1,
                        "total_discount": "5.00",
                        "fulfillment_status": null,
                        "tax_lines": []
                    }
                ],
                "shipping_lines": [
                    {
                        "id": 271878346596884000,
                        "title": "Generic Shipping",
                        "price": "10.00",
                        "code": null,
                        "source": "shopify",
                        "phone": null,
                        "requested_fulfillment_service_id": null,
                        "delivery_category": null,
                        "carrier_identifier": null,
                        "tax_lines": []
                    }
                ],
                "billing_address": {
                    "first_name": "Bob",
                    "address1": "123 Billing Street",
                    "phone": "555-555-BILL",
                    "city": "Billtown",
                    "zip": "K2P0B0",
                    "province": "Kentucky",
                    "country": "United States",
                    "last_name": "Biller",
                    "address2": null,
                    "company": "My Company",
                    "latitude": null,
                    "longitude": null,
                    "name": "Bob Biller",
                    "country_code": "US",
                    "province_code": "KY"
                },
                "shipping_address": {
                    "first_name": "Steve",
                    "address1": "123 Shipping Street",
                    "phone": "555-555-SHIP",
                    "city": "Shippington",
                    "zip": "K2P0S0",
                    "province": "Kentucky",
                    "country": "United States",
                    "last_name": "Shipper",
                    "address2": null,
                    "company": "Shipping Company",
                    "latitude": null,
                    "longitude": null,
                    "name": "Steve Shipper",
                    "country_code": "US",
                    "province_code": "KY"
                },
                "fulfillments": [],
                "refunds": [],
                "customer": {
                    "id": 115310627314723950,
                    "email": "john@test.com",
                    "accepts_marketing": false,
                    "created_at": null,
                    "updated_at": null,
                    "first_name": "John",
                    "last_name": "Smith",
                    "orders_count": 0,
                    "state": "disabled",
                    "total_spent": "0.00",
                    "last_order_id": null,
                    "note": null,
                    "verified_email": true,
                    "multipass_identifier": null,
                    "tax_exempt": false,
                    "phone": null,
                    "tags": "",
                    "last_order_name": null,
                    "default_address": {
                        "id": 715243470612851200,
                        "first_name": null,
                        "last_name": null,
                        "company": null,
                        "address1": "123 Elm St.",
                        "address2": null,
                        "city": "Ottawa",
                        "province": "Ontario",
                        "country": "Canada",
                        "zip": "K2H7A8",
                        "phone": "123-123-1234",
                        "name": "",
                        "province_code": "ON",
                        "country_code": "CA",
                        "country_name": "Canada",
                        "default": false
                    }
                }
            }"""
        )
    result

let helper_get_post() = 

    let client = new HttpClient()
    let headers = List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("","")
        }
    client.POST

let x = helper_get_request
// get the digest
let hmac = 
    x.headers 
        |> Seq.find(fun f -> fst f = "X-Shopify-Hmac-Sha256")
        |> Seq.head