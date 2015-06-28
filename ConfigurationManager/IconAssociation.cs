/*
 * Class: IconAssociation
 * Date:- 03-Aug-2014
 * Name:- Sunny
 * Description:- Class use to extract associated icon from given path. 
 *               Application must have to windows executable file. 
 *               Throws IconNotFoundException in case of any error.
 * */

using System;
using System.Drawing;

namespace Utilities
{
    /// <summary>
    /// Extract the associated icon/image for given executable path.
    /// </summary>
    public static class IconAssociation
    {
        /// <summary>
        /// Return the associated icon for given application path
        /// </summary>
        /// <param name="AppPath">Path of executable application to extract icon</param>
        /// <returns>Returns extracted Icon or throws IconNotFoundException if icon not found. </returns>
        public static Icon GetAssociatedIcon(String AppPath)
        {

            try
            {
                Icon img = Icon.ExtractAssociatedIcon(AppPath);
                return img;
            }
            catch (Exception e)
            {
                throw new IconNotFoundException(e.Message.ToString());
            }

        }

        public static Image GetAssociatedImage(String AppPath)
        {

            try
            {
                Icon img = Icon.ExtractAssociatedIcon(AppPath);
                return img.ToBitmap();
            }
            catch (Exception e)
            {
                throw new IconNotFoundException(e.Message.ToString());
            }

        }

        public class IconNotFoundException : Exception
        {

            public IconNotFoundException()
            {
            }

            public IconNotFoundException(String message)
                : base(message)
            {
            }
            public IconNotFoundException(String message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}

