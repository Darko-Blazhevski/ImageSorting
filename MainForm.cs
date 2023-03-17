namespace ImageSorting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void copyButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                copyTextBox.Text = diag.SelectedPath;
            }
            else
            {
                copyTextBox.Text = "You didn't select the folder!";
            }
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                pasteTextBox.Text = diag.SelectedPath;
            }
            else
            {
                pasteTextBox.Text = "You didn't select the folder!";
            }
        }

        private void junkButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                junkTextBox.Text = diag.SelectedPath;
            }
            else
            {
                junkTextBox.Text = "You didn't select the folder!";
            }
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                ConectingPaths();
                List<FileInfo> files = await Task.Run(() => GetFiles(pathFrom));
                progressBar.Minimum = 0;
                progressBar.Maximum = files.Count;
                int i = 0;
                List<string> FileExtensions = ConectingExtensions();
                foreach (var item in files)
                {
                    FilesPathsData filesPathsData = FileExtensions.Contains(item.Extension) ?
                        GetPicturePaths(item) : GetJunkPaths(item);
                    progressBar.Value = i;
                    i++;
                    progressLabel.Text = $"{i} out of {files.Count} files copied";
                    await Task.Run(() => File.Copy(filesPathsData.SourceFileName, filesPathsData.DestFileName, filesPathsData.Override));

                }
                MessageBox.Show($"{files.Count} files were copied!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally 
            {
                progressBar.Value = 0;
                progressLabel.Text = "";
            }

        }

        private void imageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imageBool = imageCheckBox.Checked;
        }

        private void audioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            audioBool = audioCheckBox.Checked;
        }

        private void videoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            videoBool = videoCheckBox.Checked;
        }
        static readonly List<string> imageFileExtensions = new List<string>
            {
                ".ase",".art",".bmp",".blp",".cd5",".cit",".cpt",".cr2",".cut",".dds",".dib",
                ".djvu",".egt",".exif",".gif",".gpl",".grf",".icns",".ico",
                ".iff",".jng",".jpeg",".jpg",".jfif",".jp2",".jps",".lbm",
                ".max",".miff",".mng",".msp",".nef",".nitf",".ota",".pbm",
                ".pc1",".pc2",".pc3",".pcf",".pcx",".pdn",".pgm",".PI1",
                ".PI2",".PI3",".pict",".pct",".pnm",".pns",".ppm",".psb",
                ".psd",".pdd",".psp",".px",".pxm",".pxr",".qfx",".raw",
                ".rle",".sct",".sgi",".rgb",".int",".bw",".tga",".tiff",
                ".tif",".vtf",".xbm",".xcf",".xpm",".3dv",".amf",".ai",
                ".awg",".cgm",".cdr",".cmx",".dxf",".e2d",".egt",".eps",
                ".fs",".gbr",".odg",".svg",".stl",".vrml",".x3d",".sxd",
                ".v2d",".vnd",".wmf",".emf",".art",".xar",".png",".webp",
                ".jxr",".hdp",".wdp",".cur",".ecw",".iff",".lbm",".liff",
                ".nrrd",".pam",".pcx",".pgf",".sgi",".rgb",".rgba",".bw",
                ".int",".inta",".sid",".ras",".sun",".tga",".heic",".heif"
            };
        static readonly List<string> audioFileExtensions = new List<string>
        {
            ".0CC",
            ".2SF", ".2SFLIB", ".3GA", ".3GPA", ".4MP", ".5XB", ".5XE", ".5XS", ".669", ".6CM",
            ".8CM", ".8MED", ".8SVX", ".A2B", ".A2I", ".A2M", ".A2P", ".A2T", ".A2W", ".A52",
            ".AA", ".AA3", ".AAC", ".AAX", ".AAXC", ".AB", ".ABC", ".ABM", ".AC3", ".ACB",
            ".ACD", ".ACD-BAK", ".ACD-ZIP", ".ACM", ".ACP", ".ACT", ".ADDOC", ".ADG", ".ADT", ".ADTS",
            ".ADV", ".ADX", ".AEA", ".AFC", ".AFPK", ".AGM", ".AGR", ".AHX", ".AIF", ".AIFC",
            ".AIFF", ".AIMPPL", ".AIS", ".AIX", ".AKP", ".AL", ".ALAC", ".ALAW", ".ALC", ".ALL",
            ".ALS", ".AMF", ".AMR", ".AMS", ".AMS", ".AMXD", ".AMZ", ".ANG", ".AOB", ".APE",
            ".APF", ".APL", ".ARIA", ".ARIAX", ".ASD", ".ASDT", ".ASE", ".AT3", ".ATRAC", ".AU",
            ".AU", ".AUD", ".AUDIONOTE", ".AUP", ".AUP3", ".AUP3-SHM", ".AUP3-WAL", ".AVASTSOUNDS", ".AVR", ".AWB",
            ".AWB", ".AWC", ".AXA", ".AY", ".B4S", ".BAND", ".BANK", ".BAP", ".BCS", ".BCSTM",
            ".BDD", ".BFSTM", ".BFWAV", ".BIDULE", ".BIT", ".BMML", ".BNK", ".BNL", ".BONK", ".BOX",
            ".BOX", ".BP", ".BRR", ".BRSTM", ".BUN", ".BWF", ".BWG", ".BWW", ".C01", ".CAF",
            ".CAFF", ".CAPOBUNDLE", ".CAUSTIC", ".CDA", ".CDDA", ".CDLX", ".CDO", ".CDR", ".CEL", ".CFA",
            ".CFXR", ".CGRP", ".CIDB", ".CKB", ".CKF", ".CLP", ".CMF", ".CONFORM", ".COPY", ".CPR",
            ".CPT", ".CSH", ".CTS", ".CUE", ".CVSD", ".CWB", ".CWP", ".CWS", ".CWT", ".D00",
            ".D01", ".DCF", ".DCM", ".DCT", ".DDT", ".DEWF", ".DF2", ".DFC", ".DFF", ".DIG",
            ".DJL", ".DJP", ".DJR", ".DLS", ".DM", ".DMC", ".DMF", ".DMF", ".DMSA", ".DMSE",
            ".DPDOC", ".DRA", ".DRG", ".DRM", ".DS", ".DS2", ".DSF", ".DSM", ".DSP", ".DSS",
            ".DTM", ".DTS", ".DTSHD", ".DVF", ".DW", ".DWA", ".DWD", ".EAC3", ".EAR", ".EC3",
            ".EDL", ".EFA", ".EFE", ".EFK", ".EFQ", ".EFS", ".EFV", ".EMD", ".EMP", ".EMX",
            ".EMY", ".EOP", ".ERB", ".ESPS", ".EVR", ".EVRC", ".EXPRESSIONMAP", ".EXS", ".F2R", ".F32",
            ".F3R", ".F4A", ".F64", ".FAP", ".FAR", ".FDA", ".FDP", ".FEV", ".FFF", ".FFT",
            ".FLA", ".FLAC", ".FLM", ".FLP", ".FLS", ".FPA", ".FPR", ".FRG", ".FSB", ".FSC",
            ".FSM", ".FTI", ".FTM", ".FTM", ".FTMX", ".FUZ", ".FXP", ".FZB", ".FZF", ".FZV",
            ".G721", ".G722", ".G723", ".G726", ".GBPROJ", ".GBS", ".GENH", ".GIG", ".GIO", ".GIO",
            ".GM", ".GMC", ".GP", ".GP5", ".GPBANK", ".GPK", ".GPT", ".GPX", ".GRO", ".GROOVE",
            ".GSF", ".GSFLIB", ".GSM", ".GSM", ".GUIT", ".GYM", ".H0", ".H3B", ".H3E", ".H4B",
            ".H4E", ".H5B", ".H5E", ".H5S", ".HBB", ".HBE", ".HBS", ".HCA", ".HDP", ".HES",
            ".HMA", ".HMI", ".HPS", ".HSB", ".HTK", ".IAA", ".ICS", ".IFF", ".IGP", ".IGR",
            ".IMA", ".IMF", ".IMP", ".INS", ".INS", ".INS", ".IRCAM", ".ISMA", ".IT", ".ITI",
            ".ITLS", ".ITS", ".JAM", ".JAM", ".JBX", ".JO", ".JO-7Z", ".JSPF", ".K25", ".K26",
            ".KAR", ".KC", ".KFN", ".KIN", ".KIT", ".KMP", ".KOALA", ".KOZ", ".KOZ", ".KPL",
            ".KRZ", ".KSC", ".KSD", ".KSF", ".KT2", ".KT3", ".KTP", ".L", ".LA", ".LOF",
            ".LOGIC", ".LOGICX", ".LQT", ".LSO", ".LVP", ".LWV", ".M", ".M1A", ".M2", ".M3U",
            ".M3U8", ".M3UP", ".M4A", ".M4B", ".M4P", ".M4R", ".M5P", ".MA1", ".MAMX", ".MBR",
            ".MDC", ".MDL", ".MDR", ".MED", ".MGV", ".MID", ".MIDI", ".MINI2SF", ".MINIGSF", ".MININCSF",
            ".MINIPSF", ".MINIPSF2", ".MINIUSF", ".MKA", ".MLP", ".MMF", ".MMJPROJECT", ".MMLP", ".MMM", ".MMP",
            ".MMP", ".MMPZ", ".MMV", ".MO3", ".MOD", ".MOGG", ".MON", ".MP1", ".MP2", ".MP3",
            ".MP_", ".MPA", ".MPA2", ".MPC", ".MPD", ".MPDP", ".MPGA", ".MPTM", ".MPU", ".MRP",
            ".MSCX", ".MSCZ", ".MSMPL_ALL", ".MSMPL_BANK", ".MSV", ".MT2", ".MT9", ".MTE", ".MTF", ".MTI",
            ".MTM", ".MTP", ".MTS", ".MU3", ".MUI", ".MUS", ".MUS", ".MUS", ".MUSA", ".MUSICXML",
            ".MUSX", ".MUX", ".MUX", ".MUZ", ".MWAND", ".MWS", ".MX3", ".MX4", ".MX5", ".MX5TEMPLATE",
            ".MXL", ".MXMF", ".MYR", ".MZP", ".NAAC", ".NAP", ".NARRATIVE", ".NCW", ".NFA", ".NIST",
            ".NKB", ".NKC", ".NKI", ".NKM", ".NKS", ".NKX", ".NML", ".NMSV", ".NODES", ".NOTE",
            ".NPL", ".NRA", ".NRT", ".NSA", ".NSF", ".NSFE", ".NST", ".NTN", ".NVF", ".NWC",
            ".OBW", ".ODM", ".OFR", ".OGA", ".OGG", ".OGGSTR", ".OKT", ".OMA", ".OMF", ".OMG",
            ".OMX", ".OPUS", ".ORC", ".OTA", ".OTS", ".OVE", ".OVW", ".OVW", ".PAC", ".PAF",
            ".PANDORA", ".PAT", ".PBF", ".PCA", ".PCAST", ".PCG", ".PCM", ".PD", ".PEAK", ".PEK",
            ".PHO", ".PHY", ".PJUNOXL", ".PK", ".PKF", ".PLA", ".PLST", ".PLY", ".PMPL", ".PNA",
            ".PNO", ".PPC", ".PPCX", ".PRG", ".PRG", ".PSF", ".PSF1", ".PSF2", ".PSM", ".PSY",
            ".PTCOP", ".PTF", ".PTM", ".PTS", ".PTT", ".PTX", ".PTXT", ".PVC", ".PVF", ".Q1",
            ".Q2", ".QCP", ".R", ".R1M", ".RA", ".RAD", ".RAM", ".RAW", ".RAX", ".RBS",
            ".RBS", ".RCD", ".RCY", ".RDVXZ", ".RECORD", ".REPEAKS", ".REX", ".RFL", ".RGRP", ".RIP",
            ".RMF", ".RMI", ".RMJ", ".RMM", ".RMT", ".RMX", ".RNG", ".RNS", ".ROL", ".RPL",
            ".RSF", ".RSN", ".RSO", ".RTA", ".RTI", ".RTM", ".RTS", ".RVX", ".RX2", ".RXDOC",
            ".S16", ".S3I", ".S3M", ".S3Z", ".SABL", ".SAF", ".SAM", ".SAMPLE", ".SAP", ".SB",
            ".SBG", ".SBI", ".SBK", ".SC2", ".SCS11", ".SD", ".SD", ".SD2", ".SD2F", ".SDAT",
            ".SDII", ".SDS", ".SDT", ".SDX", ".SDZ", ".SEG", ".SEQ", ".SEQUENCE", ".SERATO-STEMS", ".SES",
            ".SESX", ".SF", ".SF2", ".SFAP0", ".SFARK", ".SFK", ".SFL", ".SFPACK", ".SFS", ".SFX",
            ".SFZ", ".SGP", ".SHN", ".SIB", ".SID", ".SLP", ".SLX", ".SMA", ".SMF", ".SMP",
            ".SMP", ".SMP", ".SMPX", ".SND", ".SND", ".SND", ".SNG", ".SNG", ".SNGX", ".SNS",
            ".SNSF", ".SONG", ".SOU", ".SPH", ".SPPACK", ".SPRG", ".SPX", ".SSEQ", ".SSEQ", ".SSM",
            ".SSND", ".SSP", ".ST3", ".STAP", ".STH", ".STI", ".STM", ".STRM", ".STW", ".STX",
            ".STY", ".STY", ".SVD", ".SVP", ".SVQ", ".SVX", ".SVZ", ".SW", ".SWA", ".SWAV",
            ".SXT", ".SYH", ".SYN", ".SYN", ".SYW", ".SYX", ".TAK", ".TAK", ".TD0", ".TFMX",
            ".TG", ".THX", ".TM2", ".TM8", ".TMC", ".TOC", ".TRAK", ".TSP", ".TTA", ".TUN",
            ".TXW", ".U", ".U8", ".UAX", ".UB", ".ULAW", ".ULT", ".ULW", ".UNI", ".USF",
            ".USFLIB", ".UST", ".UW", ".UWF", ".V2M", ".VAG", ".VAL", ".VAP", ".VB", ".VC3",
            ".VCE", ".VDJ", ".VGM", ".VGZ", ".VIP", ".VLC", ".VMD", ".VMF", ".VMF", ".VMO",
            ".VOC", ".VOC", ".VOI", ".VOX", ".VOXAL", ".VPL", ".VPM", ".VPR", ".VPW", ".VQF",
            ".VRF", ".VSQ", ".VSQX", ".VTX", ".VYF", ".W01", ".W64", ".WAND", ".WAV", ".WAV",
            ".WAVE", ".WAX", ".WEBA", ".WEM", ".WFB", ".WFD", ".WFM", ".WFP", ".WMA", ".WOW",
            ".WPK", ".WPP", ".WPROJ", ".WRK", ".WTPL", ".WTPT", ".WUS", ".WUT", ".WV", ".WVC",
            ".WVE", ".WWU", ".WYZ", ".XA", ".XA", ".XBMML", ".XFS", ".XI", ".XM", ".XMA",
            ".XMF", ".XMI", ".XMS", ".XMU", ".XMZ", ".XOHT", ".XOPUS", ".XP", ".XPF", ".XRNS",
            ".XSB", ".XSP", ".XSPF", ".XT", ".XWB", ".YM", ".YOOKOO", ".ZAB", ".ZGR", ".ZPA",
            ".ZPL", ".ZSM", ".ZVD", ".ZVR"
        };
        static readonly List<string> videoFileExtensions = new List<string>
        {
            ".TY+",
            ".STR", ".SWF", ".AEP", ".MKV", ".PZ", ".PLOT", ".SFD", ".PIV", ".PSV", ".PRPROJ",
            ".KINE", ".VEG", ".RXR", ".CPVC", ".PLOTDOC", ".ANM", ".VPROJ", ".INP", ".SQZ", ".PIC",
            ".SCM", ".KDENLIVE", ".DRP", ".MSDVD", ".WLMP", ".AEC", ".BIK", ".DCR", ".MSWMM", ".WEBM",
            ".AMC", ".SCM", ".VPJ", ".WPL", ".DIR", ".CINE", ".PAC", ".FBR", ".FCP", ".EVO",
            ".MP4", ".DCR", ".SUB", ".SRT", ".MSE", ".RMVB", ".VOB", ".SSF", ".FLC", ".SBT",
            ".CLPI", ".TSV", ".IFO", ".3GP", ".DMSM", ".VSP", ".MXF", ".CAMPROJ", ".MVD", ".IVR",
            ".DMX", ".VP6", ".VTT", ".M4U", ".WMMP", ".DPA", ".AV1", ".META", ".REC", ".AEPX",
            ".MPEG", ".TRP", ".SWI", ".RCD", ".SCREENFLOW", ".MANI", ".D3V", ".MVP", ".AMX", ".MGV",
            ".HDMOV", ".RMS", ".VIDEO", ".VIV", ".ISMV", ".3GP2", ".ASF", ".VC1", ".MPV", ".DB2",
            ".WMV", ".FLV", ".PSH", ".M4S", ".SER", ".NCOR", ".PMF", ".EXI", ".RCUT", ".M2TS",
            ".MYS", ".ZM2", ".TVSHOW", ".DMSM3D", ".ALE", ".G2M", ".MPSUB", ".ARCUT", ".MEPS", ".SIV",
            ".GFP", ".JTV", ".OGV", ".MP4.INFOVID", ".DV4", ".MPROJ", ".DXR", ".MP4V", ".DAT", ".MOB",
            ".TS", ".M1V", ".CME", ".IDX", ".SCC", ".ZMV", ".GTS", ".M2T", ".IVA", ".MJ2",
            ".DREAM", ".MEPX", ".PSB", ".RM", ".M4V", ".DZM", ".TREC", ".CAMREC", ".SMV", ".MJPG",
            ".THEATER", ".TIX", ".BK2", ".MNV", ".STX", ".VRO", ".WP3", ".AWLIVE", ".F4P", ".DASH",
            ".MPEG4", ".XMV", ".VGZ", ".WVM", ".DZP", ".MOV", ".DV", ".TP", ".MPG", ".PDS",
            ".AVB", ".SFVIDCAP", ".IRCP", ".M75", ".IZZY", ".IZZ", ".FBR", ".INT", ".DVR", ".TIVO",
            ".PPJ", ".QTCH", ".CST", ".VII", ".DMB", ".FLI", ".SEDPRJ", ".TMV", ".MMP", ".PCLX",
            ".DZT", ".MEP", ".ZM3", ".MV", ".CAMV", ".FFD", ".AVV", ".KTN", ".MP5", ".DVR-MS",
            ".KMPROJECT", ".264", ".BNP", ".MTS", ".JDR", ".H264", ".PLAYLIST", ".WVX", ".AVCHD", ".SBK",
            ".CPI", ".DAV", ".VEP", ".VID", ".3G2", ".3MM", ".MP2V", ".RDB", ".MVP", ".264",
            ".M15", ".SFERA", ".XESC", ".BSF", ".60D", ".XVID", ".MPEG2", ".LVIX", ".G64", ".MOVIE",
            ".D2V", ".890", ".HEVC", ".ALPX", ".SAN", ".PGI", ".DDAT", ".YUV", ".AAF", ".F4V",
            ".G64X", ".ISM", ".MEDIA", ".MPV2", ".MPL", ".3GPP", ".OGX", ".DNC", ".HDV", ".PRO",
            ".MVEX", ".QTL", ".M4F", ".TBC", ".PDRPROJ", ".MMV", ".MP21", ".RSX", ".DCK", ".R3D",
            ".JSS", ".F4F", ".TSP", ".XLMV", ".MK3D", ".WVE", ".VCR", ".DIVX", ".BDMV", ".OGM",
            ".MOI", ".NUT", ".M2P", ".WCP", ".RV", ".VP3", ".SMK", ".SWT", ".NUV", ".SPL",
            ".K3G", ".WM", ".KMV", ".XML", ".BU", ".CED", ".AVI", ".DVDMEDIA", ".RUM", ".DPG",
            ".TDT", ".3GPP2", ".TVLAYER", ".LREC", ".WRF", ".3P2", ".MPE", ".787", ".EXO", ".ARF",
            ".BDT3", ".FLIC", ".MTV", ".M2A", ".BMC", ".VP7", ".WMD", ".RMD", ".NFV", ".TVS",
            ".LSX", ".MOOV", ".AQT", ".MPG4", ".GVI", ".AET", ".TPD", ".LRV", ".DMSD", ".JMV",
            ".W32", ".AETX", ".RMP", ".PREL", ".ZOOM", ".MJP", ".WXP", ".MVC", ".F4M", ".V264",
            ".NVC", ".IMOVIEPROJ", ".ASX", ".Y4M", ".BVR", ".TTXT", ".MOVIE", ".IRF", ".AJP", ".FTC",
            ".TVRECORDING", ".AXV", ".IMOVIELIBRARY", ".PJS", ".FVM", ".AVE", ".AVS", ".SSM", ".ORV", ".WOT",
            ".PRTL", ".MVE", ".AVD", ".VSE", ".ZEG", ".M4E", ".MV8", ".SBZ", ".CMMTPL", ".PLPROJ",
            ".EVO", ".N3R", ".NTP", ".VR", ".RCREC", ".GXF", ".WTV", ".ISMC", ".IMOVIEMOBILE", ".OTRKEY",
            ".TTML", ".BDM", ".PXV", ".RVL", ".FPDX", ".VBC", ".M21", ".SDV", ".MPGINDEX", ".RVID",
            ".AVP", ".PEG", ".SUB", ".PHOTOSHOW", ".FLH", ".TDA3MT", ".DIF", ".TOD", ".SMIL", ".VDR",
            ".M21", ".HKM", ".VCV", ".BMK", ".ROQ", ".IVF", ".ZM1", ".QT", ".DVT", ".M2V",
            ".CMPROJ", ".BRAW", ".DVX", ".PROJECTOR", ".LFPACKAGE", ".TPR", ".INSV", ".VIVO", ".MPEG1", ".AEGRAPHIC",
            ".MPL", ".SEC", ".MT2S", ".WMX", ".TP0", ".EDL", ".PAR", ".DAD", ".VCPF", ".SEC",
            ".YOG", ".RMD", ".PNS", ".QTM", ".GCS", ".AMV", ".NSV", ".VIX", ".CREC", ".XEL",
            ".CLK", ".AV", ".THP", ".PVR", ".GIFV", ".XFL", ".AM", ".DV-AVI", ".SMI", ".VFZ",
            ".FCPROJECT", ".PSSD", ".RAVI", ".ANIM", ".SSA", ".FCARCH", ".QSV", ".VFW", ".BYU", ".VLAB",
            ".BS4", ".MPC", ".VS4", ".MVB", ".SEQ", ".PROQC", ".M1PG", ".BLZ", ".MXV", ".VMD",
            ".MPLS", ".MODD", ".MOD", ".VF", ".QTZ", ".DCE", ".VIEWLET", ".VDO", ".MPG2", ".BIX",
            ".AXM", ".SPRYZIP", ".GL", ".IMOVIEPROJECT", ".PRO4DVD", ".VEM", ".AECAP", ".JTS", ".DLX", ".WSVE",
            ".CMREC", ".CMMP", ".FFM", ".EZT", ".VDX", ".XEJ", ".CVC", ".SVI", ".USF", ".STL",
            ".EXP", ".SMI", ".MOFF", ".LSF", ".H261", ".DMSS", ".SEQ", ".MSH", ".IVS", ".JV",
            ".FVT", ".CMV", ".CIP", ".FBZ", ".SCN", ".PVA", ".LXF", ".AVM", ".EYETV", ".MQV",
            ".GOM", ".AVS", ".WGI", ".AVR", ".RMV", ".RCPROJECT", ".EYE", ".MJPEG", ".SKM", ".AVC",
            ".VMLT", ".MVY", ".VP5", ".DMSD3D", ".PRO5DVD", ".CX3", ".QTINDEX", ".ISMCLIP", ".H265", ".BDT2",
            ".CAMTEMPLATE", ".ANYDESK", ".WFSP", ".AVS", ".H266", ".RTS", ".EL8", ".MGJSON", ".VMLF", ".BIK2",
            ".VSR", ".DRC", ".TY", ".CDXL", ".CAM", ".ANX", ".TDX", ".PMP", ".GVP", ".MP21",
            ".TID", ".MPF", ".RP", ".QSMD", ".SML", ".JNR", ".AV3", ".P64", ".LVF", ".VSH",
            ".MOVIE", ".FLX", ".H263", ".VFT", ".KUX", ".GRASP", ".H262", ".ML20", ".RTS", ".TGV",
            ".TGQ", ".RPL", ".RL2", ".PAF", ".MVI", ".CEL", ".PMV", ".DSY", ".PJR",
        };

        static string? pathFrom;
        static string? pathTo;
        static string? junkPath;

        static bool imageBool;
        static bool audioBool;
        static bool videoBool;




        static List<FileInfo> GetFiles(string path)
        {
            try
            {
                return Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                    ?.Select(x => new FileInfo(x))?.ToList() ?? new List<FileInfo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<FileInfo> { };
            }
            
        }

        private static FilesPathsData GetJunkPaths(FileInfo item)
        {
            string destinationPath;
            int junkCounter;
            int junkExtensionLength, junkNameLength;
            string junkName, junkExtension;

            destinationPath = $"{junkPath}\\{item.Name}";
            junkCounter = 1;

            while (File.Exists(destinationPath))
            {
                junkCounter++;

                junkExtensionLength = item.Extension.ToLower().Length;
                junkNameLength = item.Name.ToLower().Length;
                junkName = item.Name;
                junkExtension = item.Extension;
                if ((junkNameLength - junkExtensionLength) < 1)
                {
                    destinationPath = $"{junkPath}\\{junkName.Remove(junkNameLength - junkExtensionLength, junkExtensionLength)}{junkCounter}{junkExtension}";

                }
                else
                {
                    destinationPath = $"{junkPath}\\{junkName.Remove(junkNameLength - 1 - junkExtensionLength, junkExtensionLength)}{junkCounter}{junkExtension}";

                }
            }

            return new FilesPathsData
            {
                SourceFileName = item.FullName,
                DestFileName = destinationPath,
                Override = false
            };
        }

        private static FilesPathsData GetPicturePaths(FileInfo item)
        {
            int counter;
            int extensionLength, nameLength;
            string itemName, itemExtension;
            string destinationPath;

            string modstringyear, modstringmonth, finalpath;
            DateTime modDate;

            modDate = File.GetLastWriteTime(item.FullName);
            modstringyear = modDate.Year.ToString();
            modstringmonth = modDate.Month.ToString();
            finalpath = $"{pathTo}\\{modstringyear}\\{modstringmonth}";

            Directory.CreateDirectory(finalpath);
            destinationPath = $"{pathTo}\\{modstringyear}\\{modstringmonth}\\{item.Name}";
            counter = 1;

            while (File.Exists(destinationPath))
            {
                extensionLength = item.Extension.ToLower().Length;
                nameLength = item.Name.ToLower().Length;
                itemName = item.Name;
                itemExtension = item.Extension;

                destinationPath = $"{pathTo}\\{modstringyear}\\{modstringmonth}\\{itemName.Remove(nameLength - 1 - extensionLength, extensionLength)}{counter}{itemExtension}";
                counter++;
            }

            return new FilesPathsData
            {
                SourceFileName = item.FullName,
                DestFileName = destinationPath,
                Override = false
            };
        }

        private void ConectingPaths()
        {
            pathFrom = copyTextBox.Text;
            pathTo = pasteTextBox.Text;
            junkPath = junkTextBox.Text;
        }

        private List<string> ConectingExtensions()
        {


            List<string> mergedList = (imageBool ? imageFileExtensions.Concat(imageFileExtensions.Select(s => s.ToUpper())) : new List<string>())
                                 .Concat(audioBool ? audioFileExtensions.Concat(audioFileExtensions.Select(s => s.ToLower())) : new List<string>())
                                 .Concat(videoBool ? videoFileExtensions.Concat(videoFileExtensions.Select(s => s.ToLower())) : new List<string>())
                                 .ToList();
            return mergedList;
            // mergedList contains the elements from list1 and/or list2 and/or list3, with list1 repeated in uppercase if bool1 is true
        }
    }
}