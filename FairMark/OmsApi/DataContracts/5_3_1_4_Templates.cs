namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.4. Справочник «Шаблоны КМ» (templateId)
    /// </summary>
    public static class Templates
    {
        /// <summary>
        /// 1. 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Обувные товары
        /// </remarks>
        public static int T1 = 1;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (7 chars) + 8005 (6 chars)
        /// </summary>
        /// <remarks>
        /// Табачная продукция (блоки)
        /// </remarks>
        public static int T3 = 3;

        /// <summary>
        /// GTIN + SERIAL (7 chars) + МРЦ
        /// </summary>
        /// <remarks>
        /// Табачная продукция (пачки)
        /// </remarks>
        public static int T4 = 4;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Лекарственные препараты для медицинского применения
        /// </remarks>
        public static int T5 = 5;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Шины и покрышки пневматические резиновые новые
        /// </remarks>
        public static int T7 = 7;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (20 chars)
        /// </summary>
        /// <remarks>
        /// Фотокамеры (кроме кинокамер), фотовспышки и лампы-вспышки
        /// </remarks>
        public static int T8 = 8;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Духи и туалетная вода
        /// </remarks>
        public static int T9 = 9;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Предметы одежды, белье постельное, столовое, туалетное и кухонное
        /// </remarks>
        public static int T10 = 10;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Велосипеды и велосипедные рамы
        /// </remarks>
        public static int T11 = 11;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Кресла коляски
        /// </remarks>
        public static int T12 = 12;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (7 chars)
        /// </summary>
        /// <remarks>
        /// Альтернативная табачная продукция (GS1)
        /// </remarks>
        public static int T14 = 14;

        /// <summary>
        /// GTIN + SERIAL (7 chars)+ МРЦ (АААА)
        /// </summary>
        /// <remarks>
        /// Альтернативная табачная продукция (non GS1)
        /// </remarks>
        public static int T15 = 15;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Упакованная вода
        /// </remarks>
        public static int T16 = 16;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (13 chars)
        /// </summary>
        /// <remarks>
        /// Пиво, напитки, изготавливаемые на основе пива и слабоалкогольные напитки
        /// </remarks>
        public static int T18 = 18;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (6 chars)
        /// </summary>
        /// <remarks>
        /// Молочная продукция
        /// </remarks>
        public static int T20 = 20;

        /// <summary>
        /// 01 + GTIN + 21 + SERIAL (7 chars) + МРЦ (000000)
        /// </summary>
        /// <remarks>
        /// Никотиносодержащая продукция (блоки)
        /// </remarks>
        public static int T21 = 21;

        /// <summary>
        /// GTIN + SERIAL (7 chars) + МРЦ (АААА)
        /// </summary>
        /// <remarks>
        /// Никотиносодержащая продукция (пачки)
        /// </remarks>
        public static int T22 = 22;
    }
}
