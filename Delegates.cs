// делегаты доступные остальным компанентам

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Делегат значение изменено
    /// </summary>
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    /// <summary>
    ///     Делегат значение изменено
    /// </summary>
    public delegate void ObjectChangedEventHandler(object sender, ObjectChangedEventArgs e);
}