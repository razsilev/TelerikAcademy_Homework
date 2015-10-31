<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:d="urn:students"
    xmlns:e="http://schemas.microsoft.com/ado/2006/04/edm"
>
    <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/">
      <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
      </xsl:text>
      <html>
        <body>
          <h2>Students</h2>
          <table border="1" style="border-collapse: collapse;">
            <tr bgcolor="#CCC">
              <th>name</th>
              <th>sex</th>
              <th>birth date</th>
              <th>email</th>
              <th>phone</th>
              <th>specialty</th>
              <th>Exams</th>
            </tr>
          <xsl:for-each select="d:students/d:student">
            <tr>
              <td><xsl:value-of select="d:name"/></td>
              <td><xsl:value-of select="d:sex"/></td>
              <td><xsl:value-of select="d:birthDate"/></td>
              <td><xsl:value-of select="d:email"/></td>
              <td><xsl:value-of select="d:phone"/></td>
              <td><xsl:value-of select="d:specialty"/></td>
              <td>
                <table border="1" style="border-collapse: collapse;">
                  <tr>
                    <th>exam name</th>
                    <th>tutor</th>
                    <th>score</th>
                  </tr>
                  <xsl:for-each select="e:takenExams/d:exam">
                    <tr>
                      <td><xsl:value-of select="d:examName"/></td>
                      <td><xsl:value-of select="d:tutor"/></td>
                      <td><xsl:value-of select="d:score"/></td>
                    </tr>
                  </xsl:for-each>
                </table>              
              </td>
            </tr>
          </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
