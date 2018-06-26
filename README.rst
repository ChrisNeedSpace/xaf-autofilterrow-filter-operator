===================================================
XAF AutoFilterRow with configurable operator - v1.0
===================================================
-----------------------------
Compatible with XAF versions:
-----------------------------
- 17.2.7
- **WIN & WEB**

-----------
Description
-----------
This is a feature for **DevExpress eXpressAppFramework (XAF)** that provides AutoFilterRow with configurable operator - a mechanism that enables to specify in code or via model the default auto filter row operator for each field separately.

**Functionality**

- specify default auto filter row operator via attibute per property:  [AutoFilterRowCondition(AutoFilterRowCondition.BeginsWith)]
- specify default auto filter row operator via model per model member.

**Significant Files**

- TestProject17_2.Module\AutoFilterRow\AutoFilterRowConditionAttribute.cs
- TestProject17_2.Module\AutoFilterRow\IModelMemberAutoFilterRow.cs
- TestProject17_2.Module\Module.cs
- TestProject17_2.Module.Win\Controllers\AutoFilterRow\WinAutoFilterRowConditionController.cs
- TestProject17_2.Module.Web\Controllers\AutoFilterRow\WebAutoFilterRowConditionController.cs

**Example Of Use**

Just include the Significant Files to your project.
Have fun!

**Screenshots**

.. image:: https://raw.github.com/KrzysztofKielce/xaf-autofilterrow-filter-operator/master/Screenshot1.png

and

.. image:: https://raw.github.com/KrzysztofKielce/xaf-autofilterrow-filter-operator/master/Screenshot2.png

and

.. image:: https://raw.github.com/KrzysztofKielce/xaf-autofilterrow-filter-operator/master/Screenshot3.png

------------
Installation
------------
#. Install XAF_.
#. Get the source code for this plugin from github_, either using git_, or downloading directly:

   - To download using git, install git and then type 
     ``git clone git@github.com:KrzysztofKielce/xaf-autofilterrow-filter-operator.git backup``
     at the command prompt (on Linux, Windows is a bit different)
   - To download directly, go to the `project page`_ and click **Download**

#. Open a XAF Web project (or create one) and include the property editor file.


.. _XAF: http://go.devexpress.com/DevExpressDownload_UniversalTrial.aspx
.. _git: http://git-scm.com/
.. _github:
.. _project page: https://github.com/KrzysztofKielce/xaf-autofilterrow-filter-operator


----------
Disclaimer
----------
This is **beta** code.  It is probably okay for production environments, but may not work exactly as expected.  Refunds will not be given.  If it breaks, you need to keep both parts.

-------
License
-------
All code herein is under the Do What The Fuck You Want To Public License (WTFPL_).

.. _WTFPL: http://www.wtfpl.net/

---------
About XAF
---------
The eXpressApp Framework (XAF) is a modern and flexible application framework that allows you to create powerful line-of-business applications that simultaneously target Windows and the Web. XAF's scaffolding of the database and UI allows you to concentrate on business rules without the many distractions and tedious tasks normally associated with Windows and Web development. XAF's modular design facilitates a plug and play approach to common business requirements such as security and reporting.

XAF's advantages when compared with a more traditional approach to app development are profound. See for yourself and learn why XAF can radically increase productivity and help you bring solutions to market faster than you've ever thought possible.

For more information, visit:

http://www.devexpress.com/Products/NET/Application_Framework/
