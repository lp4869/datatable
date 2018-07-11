using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST_PAGING.VDCBackOfficeService;

namespace TEST_PAGING.Models
{

    public class Datatable
    {
        //public int draw { get; set; }
        //public int recordsTotal { get; set; }
        //public int recordsFiltered { get; set; }
        public List<VDC_ATV_MST_CONSULAR_MAPPING_DTO> data { get; set; }
    }
    public class VDC_ATV_MST_CONSULAR
    {
        public List<VDC_ATV_MST_CONSULAR_MAPPING_DTO> GetAllDATA(String ConsularMappingId)
        {
            List<VDC_ATV_MST_CONSULAR_MAPPING_DTO> result = new List<VDC_ATV_MST_CONSULAR_MAPPING_DTO>();
            using (VDCBackOfficeServiceClient serv = new VDCBackOfficeServiceClient())
            {
                long? ConsularMapping = null;
                if (!String.IsNullOrEmpty(ConsularMappingId))
                {
                    ConsularMapping = Int32.Parse(ConsularMappingId);
                }
                var ClientResult = serv.VMstConsularMapping(ConsularMapping);
                if (ClientResult.IsSuccessful)
                {
                    if (ClientResult.Results != null)
                    {
                        result = ClientResult.Results.Select(s => new VDC_ATV_MST_CONSULAR_MAPPING_DTO {
                            CONSULAR_MAPPING_ID = s.CONSULAR_MAPPING_ID,
                            PASSPORT_COUNTRY_CODE = s.PASSPORT_COUNTRY_CODE,
                            PASSPORT_COUNTRY_NAME = s.PASSPORT_COUNTRY_NAME,
                            COUNTRY_OF_RESIDENCE = s.COUNTRY_OF_RESIDENCE,
                            COUNTRY_OF_RESIDENCE_NAME = s.COUNTRY_OF_RESIDENCE_NAME,
                            CONSULAR_CODE = s.CONSULAR_CODE,
                            CONSULAR_NAME = s.CONSULAR_NAME,
                            IS_ACTIVE = s.IS_ACTIVE,
                            INFO_MESSAGE_ID = s.INFO_MESSAGE_ID,
                            APPROVE_MESSAGE_ID = s.APPROVE_MESSAGE_ID,
                            INFO_MESSAGE_NAME = s.INFO_MESSAGE_NAME,
                            APPROVE_MESSAGE_NAME = s.APPROVE_MESSAGE_NAME,
                        }).ToList();
                    }
                }
                // json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(result);
            }
            return result;
        }
    }
    public class VDC_ATV_MST_CONSULAR_MAPPING_DTO
    {
        public long? CONSULAR_MAPPING_ID { get; set; }
        public string PASSPORT_COUNTRY_CODE { get; set; }
        public string PASSPORT_COUNTRY_NAME { get; set; }
        public string COUNTRY_OF_RESIDENCE { get; set; }
        public string COUNTRY_OF_RESIDENCE_NAME { get; set; }
        public string CONSULAR_CODE { get; set; }
        public string CONSULAR_NAME { get; set; }
        public string IS_ACTIVE { get; set; }
        public long? INFO_MESSAGE_ID { get; set; }
        public long? APPROVE_MESSAGE_ID { get; set; }
        public string INFO_MESSAGE_NAME { get; set; }
        public string APPROVE_MESSAGE_NAME { get; set; }

    }
}