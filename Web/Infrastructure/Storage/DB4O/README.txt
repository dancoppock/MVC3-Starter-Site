Hi, it's me... Rob...

This is DB4O, and object database that stores your object instances in binary format, completely
removing the pain of working with a relational database and a OO object model. For some, that's not
a big deal - but give it time... it will be.

If you want to know more about working with DB4O, you can read it on my blog:
http://blog.wekeroad.com/2010/02/06/nosql-a-practical-approach-part-1

The data store for DB4O is a file, and it's stored in your App_Data directory, called "Store.db4o".
If you want to visualize the data, you can - there's a download you can get that installs a
driver in VisualStudio so your data looks like it's coming from DB:
http://www.youtube.com/watch?v=0DzxvblyEcA

The above video is horrible, but shows how it works.

DB4O is *not* free, but the increase in your development time will be well worth the cost. Here's more info:
http://www.db4o.com/about/productinformation/db4o/

If you use DB4O for a website, make sure that you use the ReadOnly container for quick reads (as a singleton)
and save data with the ISession stuff.