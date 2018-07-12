using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST_PAGING.VDCBackOfficeService;

namespace TEST_PAGING.Models
{
    public class Datatable
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class VDC_ATV_MST_CONSULAR
    {
        public IList<VDC_ATV_MST_CONSULAR_MAPPING_DTO> YourCustomSearchFunc(Datatable model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            if (model.order != null)
            {
                // in this example we just default sort on the 1st column
                sortBy = model.columns[model.order[0].column].data;
                sortDir = model.order[0].dir.ToLower() == "asc";
            }

            // search the dbase taking into consideration table sorting and paging
            var result = GetAllDATA(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);
            if (result == null)
            {
                // empty collection...
                return new List<VDC_ATV_MST_CONSULAR_MAPPING_DTO>();
            }
            return result;
        }
        private List<VDC_ATV_MST_CONSULAR_MAPPING_DTO> GetAllDATA(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
        {
            List<VDC_ATV_MST_CONSULAR_MAPPING_DTO> result = new List<VDC_ATV_MST_CONSULAR_MAPPING_DTO>();
           // var whereClause = BuildDynamicWhereClause(Db, searchBy);

            if (String.IsNullOrEmpty(searchBy))
            {
                // if we have an empty search then just order the results by Id ascending
                sortBy = "Id";
                sortDir = true;
            }
            using (VDCBackOfficeServiceClient serv = new VDCBackOfficeServiceClient())
            {
                long? ConsularMapping = null;

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
                filteredResultsCount = result.Count();
                totalResultsCount = result.Count();
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