using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows;

namespace WebApplication1.Controllers
{

    public class BinaController : ApiController
    {
        StajerDbEntities db = new StajerDbEntities();

        [HttpGet]
        [Route("api/BinaList")]
        public List<BinaListesi> BinaList()
        {

            var bina = db.Bina.Select(x => new BinaListesi
            {
                BinaNumarasi = x.BinaNumarasi,
                BinaId = x.BinaId
            }).ToList();
            return bina;
        }
        public class BinaListesi
        {
            public string YatakSayisi { get; set; }
            public string OdaNumarasi { get; set; }
            public string BinaNumarasi { get; set; }
            public int BinaId { get; set; }
        }

        [HttpPost]
        [Route("api/DeleteBina")]
        public IHttpActionResult PostNewBinaId(int BinaId)
        {
            using (var ctx = new StajerDbEntities())
            {
                //var bina = ctx.Bina.Where(x => x.BinaId == BinaId).FirstOrDefault();

                var oda = ctx.Oda.Where(x => x.BinaId == BinaId).FirstOrDefault();
                var binaa = ctx.Bina.Select(x => x.BinaNumarasi).FirstOrDefault();
                //foreach (var item in oda)
                //{
                //    var misafir = ctx.Misafirler.Where(x => x.OdaId == item.BinaId).FirstOrDefault();
                //    if (misafir != null)
                //    {
                //        ctx.Misafirler.Remove(misafir);
                //    }
                //}
                //ctx.Bina.Remove(bina);

                ctx.Oda.Remove(oda);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/UpdateBina")]
        public IHttpActionResult PostNewDuzenle(BinaListesi bina)
        {
            using (var ctx = new StajerDbEntities())
            {
                var a = ctx.Oda.Where(x => x.BinaId == bina.BinaId).FirstOrDefault();
                a.OdaNumarasi = bina.OdaNumarasi;
                a.BinaId = bina.BinaId;
                a.Yatak_Sayisi = bina.YatakSayisi;
                bina.BinaNumarasi = bina.BinaNumarasi;
                //ctx.Oda.Remove(a);
                ctx.SaveChanges();
            }
            return Ok();
        }



        [HttpPost]
        [Route("api/AddBina")]
        public IHttpActionResult PostNewBina(BinaListesi bina)
        {
            using (var ctx = new StajerDbEntities())
            {


                Oda ba = new Oda();
                ba.BinaId = bina.BinaId;
                ba.OdaNumarasi = bina.OdaNumarasi;
                ba.Yatak_Sayisi = bina.YatakSayisi;
                var bb = (from t in db.Bina
                          where t.BinaId == bina.BinaId
                          select t).FirstOrDefault();
               
                ctx.Oda.Add(ba);
                ctx.SaveChanges();

            }
            return Ok();
        }


        [HttpGet]
        [Route("api/AllOdaList")]
        public List<OdaListesi> OdaList()
        {
            var bina = db.Oda.Select(x => new OdaListesi
            {
                BinaId = x.BinaId,
                BinaNumarasi = x.Bina.BinaNumarasi,
                OdaNumarasi = x.OdaNumarasi,
                YatakSayisi = x.Yatak_Sayisi
            }).ToList();
            return bina;
        }

        [HttpGet]
        [Route("api/OdaList")]
        public List<OdaListesi> OdaList2()
        {
            var bina = db.Oda.Select(x => new OdaListesi
            {
                BinaNumarasi = x.Bina.BinaNumarasi,
                YatakSayisi = x.Yatak_Sayisi,
                OdaNumarasi = x.OdaNumarasi,
                BinaId = x.BinaId,
            }).ToList();
            return bina;
        }

        public class OdaListesi
        {
            public string OdaNumarasi { get; set; }
            public string BinaNumarasi { get; set; }
            public int OdaId { get; set; }
            public int BinaId { get; set; }
            public string YatakSayisi { get; set; }
        }
     
    }
}

