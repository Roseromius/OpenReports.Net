using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenReports.Net
{
    public class UCPC : IModel
    {
        public string Code { get; private set; }
        public PrimaryObjectType Type { get; private set; }
        public string SeedCompanyCode { get; private set; }
        public string StrainCode { get; private set; }
        public string ProducerCode { get; private set; }
        public string ProductCode { get; private set; }
        public string BatchCode { get; private set; }
        public bool HasErrors { get; private set; }

        public UCPC(string ucpc, PrimaryObjectType type)
        {
            if (ucpc.Length == 25)
            {
                var regex = new Regex("^[a-zA-Z0-9]*$");

                if (regex.IsMatch(ucpc))
                {
                    Code = ucpc;
                    Type = type;
                    ParseCode(ucpc, type);
                    if (!VerifyObjectType(type))
                    {
                        HasErrors = true;
                    }
                }
                else
                {
                    throw new Exception("UCPC code must be Alphanumeric.");
                }
            }
            else
            {
                throw new Exception("UCPC code must be 25 characters in length. (Alphanumeric)");
            }
        }

        private void ParseCode(string ucpc, PrimaryObjectType type)
        {
            SeedCompanyCode = PadPartialCode(PrimaryObjectType.SeedCompany, ucpc.Substring(0,5));
            StrainCode = PadPartialCode(PrimaryObjectType.Strain, ucpc.Substring(5, 5));
            ProducerCode = PadPartialCode(PrimaryObjectType.Producer, ucpc.Substring(10, 5));
            ProductCode = PadPartialCode(PrimaryObjectType.Product, ucpc.Substring(15, 5));
            BatchCode = PadPartialCode(PrimaryObjectType.Batch, ucpc.Substring(20, 5));
        }

        private bool VerifyObjectType(PrimaryObjectType type)
        {
            switch (type)
            {
                case PrimaryObjectType.Strain:
                    if (StrainCode == "0000000000000000000000000") { return false; }
                    break;
                case PrimaryObjectType.Product:
                    if (ProductCode == "0000000000000000000000000") { return false; }
                    break;
                case PrimaryObjectType.Producer:
                    if (ProducerCode == "0000000000000000000000000") { return false; }
                    break;
                case PrimaryObjectType.SeedCompany:
                    if (SeedCompanyCode == "0000000000000000000000000") { return false; }
                    break;
                case PrimaryObjectType.Batch:
                    if (BatchCode == "0000000000000000000000000") { return false; }
                    break;
                default:
                    return false;
            }

            return true;
        }

        private string PadPartialCode(PrimaryObjectType type, string partialUCPC)
        {
            switch (type)
            {
                case PrimaryObjectType.Strain:
                    return "00000" + partialUCPC.PadRight(20, '0');
                case PrimaryObjectType.Product:
                    return "000000000000000" + partialUCPC.PadRight(10, '0');
                case PrimaryObjectType.Producer:
                    return "0000000000" + partialUCPC.PadRight(15, '0');
                case PrimaryObjectType.SeedCompany:
                    return partialUCPC.PadRight(25, '0');
                case PrimaryObjectType.Batch:
                    return partialUCPC.PadLeft(25, '0');
            }

            return "";
        }

        public bool IsValid()
        {
            if (SeedCompanyCode.Length == 0) { return false; }
            if (StrainCode.Length == 0) { return false; }
            if (ProducerCode.Length == 0) { return false; }
            if (ProductCode.Length == 0) { return false; }
            if (BatchCode.Length == 0) { return false; }

            if (Code == null)
            {
                return false;
            }
            if (Type == PrimaryObjectType.Unassigned)
            {
                return false;
            }

            return true;
        }
    }
}
